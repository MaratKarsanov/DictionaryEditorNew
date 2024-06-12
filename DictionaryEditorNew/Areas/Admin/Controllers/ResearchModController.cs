﻿using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResearchModController : Controller
    {
        private readonly OssetianWordsDbRepository ossetianWordsDbRepository;
        public ResearchModController(OssetianWordsDbRepository ossetianWordsDbRepository)
        {
            this.ossetianWordsDbRepository = ossetianWordsDbRepository;
        }

        public IActionResult Index()
        {
            List<OssetianWord> wordsList = ossetianWordsDbRepository.GetWords();
            return View(wordsList);
        }

        public IActionResult OneWord(Guid id)
        {
            OssetianWord ossetianWord = ossetianWordsDbRepository.TryGetById(id);
            return View(ossetianWord);
        }
    }
}
