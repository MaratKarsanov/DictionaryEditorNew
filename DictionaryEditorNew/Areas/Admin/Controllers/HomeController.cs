using Microsoft.AspNetCore.Mvc;
using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using DictionaryEditorNew.Models;


namespace DictionaryEditorNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserDbRepository userRepository;
        public HomeController(UserDbRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            string userLogin = Request.Cookies["userLogin"] ?? "User";
            User user = userRepository.TryGetByLogin(userLogin);
            if (user != null) ViewBag.NavbarType = user.Role.Name.ToString();
            return View();
        }

        //public IActionResult Devs()
        //{
        //    return View();
        //}
    }
}
