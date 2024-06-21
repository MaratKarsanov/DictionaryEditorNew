using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Areas.Redactor.Controllers
{
    [Area("Redactor")]
    public class ResearchModController : Controller
    {
        private readonly OssetianWordsDbRepository ossetianWordsDbRepository;
        public ResearchModController(OssetianWordsDbRepository ossetianWordsDbRepository)
        {
            this.ossetianWordsDbRepository = ossetianWordsDbRepository;
        }

        public IActionResult Index()
        {
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
