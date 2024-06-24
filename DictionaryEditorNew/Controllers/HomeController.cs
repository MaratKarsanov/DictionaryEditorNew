using Microsoft.AspNetCore.Mvc;
using DictionaryEditorDbNew.Models;
using DictionaryEditorNew.Models;
using DictionaryEditorDbNew.Repositories;
using DictionaryEditorDbNew;
using Newtonsoft.Json;


namespace DictionaryEditorNew.Controllers
{
    public class HomeController : Controller
    {
        private RoleDbRepository roleRepository;
        private UserDbRepository userRepository;
        private readonly DatabaseContext databaseContext;
        private readonly RussianWordsDbRepository russianWordsDbRepository;
        private readonly OssetianWordsDbRepository ossetianWordsDbRepository;
        private readonly ExamplesDbRepository examplesDbRepository;
        private readonly DictionariesRepository dictionariesDbRepository;
        public HomeController(DatabaseContext databaseContext,
            RussianWordsDbRepository russianWordsDbRepository,
            OssetianWordsDbRepository ossetianWordsDbRepository,
            ExamplesDbRepository examplesDbRepository,
            UserDbRepository userRepository,
            RoleDbRepository roleRepository,
            DictionariesRepository dictionariesDbRepository)
        {
            this.databaseContext = databaseContext;
            this.russianWordsDbRepository = russianWordsDbRepository;
            this.examplesDbRepository = examplesDbRepository;
            this.ossetianWordsDbRepository = ossetianWordsDbRepository;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.dictionariesDbRepository = dictionariesDbRepository;
            if (roleRepository.GetAll().Count() == 0)
            {
                roleRepository.Add(new Role() { Name = "User" });
                roleRepository.Add(new Role() { Name = "Admin" });
                roleRepository.Add(new Role() { Name = "Redactor" });
            }
            if (userRepository.GetAll().Count() == 0)
            {
                userRepository.Add(new User()
                {
                    Login = "marat",
                    Password = "marat",
                    Name = "marat",
                    Surname = "marat",
                    Role = roleRepository.TryGetByName("Admin")
                });
            }
            if (dictionariesDbRepository.GetAll().Count == 0)
            {
                var reader = new StreamReader("C:\\Users\\79187\\source\\repos\\DictionaryEditorNew4\\DictionaryEditorNew\\wwwroot\\json\\json.json");
                var res = JsonConvert.DeserializeObject<List<Word>>(reader.ReadToEnd());
                var newDict = new Dictionary() { Id = Guid.NewGuid(), Name = "Осетино-русский" };
                dictionariesDbRepository.AddDict(newDict);
                foreach (var word in res)
                {
                    var ossetianWord = new ForeignWord
                    {
                        Id = Guid.NewGuid(),
                        Word = word.OssetianWord,
                        Dictionary = newDict,
                    };
                    ossetianWordsDbRepository.AddWord(ossetianWord);
                    foreach (var meaning in word.Meanings)
                    {
                        foreach (var translation in meaning.Translations)
                        {
                            var existingRussianWord = russianWordsDbRepository.TryGetByWord(translation);
                            if (existingRussianWord != null)
                            {
                                existingRussianWord.ForeignWords.Add(ossetianWord);
                                ossetianWord.RussianWords.Add(existingRussianWord);
                                databaseContext.SaveChanges();
                            }
                            else
                            {
                                var newRussianWord = new RussianWord
                                {
                                    Id = Guid.NewGuid(),
                                    Word = translation,
                                    ForeignWords = new List<ForeignWord>()
                                {
                                    ossetianWord
                                },
                                };
                                ossetianWord.RussianWords.Add(newRussianWord);
                                russianWordsDbRepository.AddWord(newRussianWord);
                            }
                        }
                        foreach (var example in meaning.Examples)
                        {
                            var newExample = new Example
                            {
                                Id = Guid.NewGuid(),
                                Sentence = example.Item1,
                                Translation = example.Item2,
                                ForeignWord = ossetianWord
                            };
                            examplesDbRepository.AddExample(newExample);
                        }
                    }
                }
            }
        }

        public IActionResult Index()
        {
            string userLogin = Request.Cookies["userLogin"] ?? "User";
            User user = userRepository.TryGetByLogin(userLogin);
            if(user != null)ViewBag.NavbarType = user.Role;
            if (user == null) 
                return View();
            else if(user.RoleName == "Admin")
                return RedirectToAction("Index", "Home", new { area = "Admin"});
            else if (user.RoleName == "User")
                return RedirectToAction("Index", "Home", new { area = "RegisteredUser"});
            else if (user.RoleName == "Redactor")
                return RedirectToAction("Index", "Home", new { area = "Redactor"});
            else return View();
        }

        public IActionResult Devs()
        {
            return View();
        }
    }
}
