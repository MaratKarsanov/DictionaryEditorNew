using DictionaryEditorDbNew.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Controllers
{

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
           
            var user = userRepository.TryGetByLogin(userName);
            ViewData["userRole"] = user.Role.Name;

            return View("Index");
           
        }
    }
}
