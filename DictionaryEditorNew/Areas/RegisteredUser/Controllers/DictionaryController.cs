using DictionaryEditorDbNew;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Areas.RegisteredUser.Controllers
{
    [Area("RegisteredUser")]
    public class DictionaryController : Controller
    {
        private UserDbRepository userRepository;
        public DictionaryController(UserDbRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var userName = Request.Cookies["userLogin"];
            if (userName is null || userName == string.Empty)
                return RedirectToAction("Index", "ResearchMod");
            var user = userRepository.TryGetByLogin(userName);
            ViewData["userRole"] = user.Role.Name;
            if (user.Role.Name == "Admin")
                return View("Admin");
            else return RedirectToAction("Index", "ResearchMod");
        }
    }
}
