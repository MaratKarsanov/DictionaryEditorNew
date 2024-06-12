using Microsoft.AspNetCore.Mvc;
using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using DictionaryEditorNew.Models;


namespace DictionaryEditorNew.Areas.RegisteredUser.Controllers
{
    [Area("RegisteredUser")]
    public class HomeController : Controller
    {
        
        public HomeController()
        {
                              
        }

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
