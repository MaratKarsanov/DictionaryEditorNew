using DictionaryEditorDbNew.Models;
using DictionaryEditorDbNew.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Controllers
{
    public class ResearchModController : Controller
    {
        private readonly OssetianWordsDbRepository ossetianWordsDbRepository;
        private readonly UserDbRepository userRepository;
        public ResearchModController(OssetianWordsDbRepository ossetianWordsDbRepository, UserDbRepository userRepository)
        {
            this.ossetianWordsDbRepository = ossetianWordsDbRepository;
            this.userRepository = userRepository;
        }

        //public IActionResult Index()
        //{          
        //    List<ForeignWord> wordsList = ossetianWordsDbRepository.GetWords();
        //    return View(wordsList);
        //}
        public IActionResult Index(string? userRole)
        {
            var userName = Request.Cookies["userLogin"];
            if (userName is null || userName == string.Empty)
                return RedirectToAction("Index");
            var user = userRepository.TryGetByLogin(userName);
            ViewData["userRole"] = user.Role.Name;

            List<ForeignWord> wordsList = ossetianWordsDbRepository.GetWords();
            return View(wordsList);
        }

        public IActionResult OneWord(Guid id)
        {
            ForeignWord ossetianWord = ossetianWordsDbRepository.TryGetById(id);
            return View(ossetianWord);
        }
    }
}
