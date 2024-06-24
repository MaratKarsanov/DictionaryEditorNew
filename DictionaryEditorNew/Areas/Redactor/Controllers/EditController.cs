using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using DictionaryEditorDbNew.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Linq;


namespace DictionaryEditorNew.Areas.Redactor.Controllers
{
    [Area("Redactor")]
    public class EditController : Controller
    {
        private readonly OssetianWordsDbRepository ossetianWordsDbRepository;
        private readonly RussianWordsDbRepository russianWordsDbRepository;
        private readonly DatabaseContext databaseContext;
        public RusWordsHashSet rusWordsHashSet;

        public EditController(OssetianWordsDbRepository ossetianWordsDbRepository, DatabaseContext databaseContext, RusWordsHashSet rusWordsHashSet, RussianWordsDbRepository russianWordsDbRepository)
        {
            this.ossetianWordsDbRepository = ossetianWordsDbRepository;
            this.databaseContext = databaseContext;
            this.rusWordsHashSet = rusWordsHashSet;
            this.russianWordsDbRepository= russianWordsDbRepository;
        }

        public IActionResult Index(string returnToLastWord)
        {
            ViewBag.NavbarType = "Redactor";
            if (!string.IsNullOrEmpty(returnToLastWord))
            {
                return View(ossetianWordsDbRepository.GetWords());
            }
            if (Request.Cookies["lastWordId"] is not null && Request.Cookies["lastWordId"] != string.Empty)
                return RedirectToAction("OneWord", "Edit", new { area = "Redactor", id = Guid.Parse(Request.Cookies["lastWordId"]) });
            return View(ossetianWordsDbRepository.GetWords());
        }
        public IActionResult OneWord(Guid id)
        {
            ForeignWord word = ossetianWordsDbRepository.TryGetById(id);
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(1)
            };
            Response.Cookies.Append("lastWordId", id.ToString(), cookieOptions);
            return View(word);
        }

        [HttpPost]
        public IActionResult SaveChanges(Guid id, string? word, string rusWords)
        {
            ForeignWord ossetWord = ossetianWordsDbRepository.TryGetById(id);
            if (word != null) { ossetWord.Word = word; }
           
          
           

            List<string> allRusTrans = rusWords.Split(new[] { ',', '.', ';', ':', '-', '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string rusTrans in allRusTrans)
            {
                if (!rusWordsHashSet.rusWords.Contains(rusTrans)) //если в хэш сете нет слова
                {                   
                    russianWordsDbRepository.AddNewWord(rusTrans, ossetWord);//создаем новое RussianWord                   
                }
                else if (!ossetWord.RussianWords.Select(x => x.Word).Contains(rusTrans))//если в хэш сете есть, а у нашего осетинского слова нет
                {
                    RussianWord russianWord = russianWordsDbRepository.TryGetByWord(rusTrans);
                    ossetWord.RussianWords.Add(russianWord);//создаем связь
                }
                
            }
            List<RussianWord> needDelete = new List<RussianWord>();
            foreach (var rusWordss in ossetWord.RussianWords)//проверка на удалание
            {
                
                if (!allRusTrans.Contains(rusWordss.Word)) //если у осет слова есть то, чего нет в пришедшем списке
                {
                    needDelete.Add(rusWordss);//добавим в список на удаление, потому что нельзя в цикле менять лист
                    //ossetWord.RussianWords.Remove(rusWordss);//удаляем связь осет слова с тем, чего нет в списке
                    rusWordss.ForeignWords.Remove(ossetWord);//и наоборот
                                      
                }
                
            }
            foreach (var wordToDelete in needDelete)
            {
                ossetWord.RussianWords.Remove(wordToDelete);
            }


            databaseContext.SaveChanges();

            return RedirectToAction(nameof(Index), new { returnToLastWord = "true"});
        }
    }
}
