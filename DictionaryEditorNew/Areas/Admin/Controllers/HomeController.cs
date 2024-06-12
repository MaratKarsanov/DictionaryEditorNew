using Microsoft.AspNetCore.Mvc;
using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using DictionaryEditorNew.Models;


namespace DictionaryEditorNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Devs()
        {
            return View();
        }
    }
}
