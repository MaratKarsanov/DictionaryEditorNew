using Microsoft.AspNetCore.Mvc;
using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;
using DictionaryEditorNew.Models;


namespace DictionaryEditorNew.Controllers
{
    public class HomeController : Controller
    {
        private RoleDbRepository roleRepository;
        private UserDbRepository userRepository;
        public HomeController(RoleDbRepository roleRepository, UserDbRepository userRepository)
        {
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
            if (roleRepository.GetAll().Count() == 0)
            {
                roleRepository.Add(new Role() { Name = "User" });
                roleRepository.Add(new Role() { Name = "Admin" });
                roleRepository.Add(new Role() { Name = "Redactor" });
            }
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var userLogin = Request.Cookies["userLogin"] ?? "User";
            var user = userRepository.TryGetByLogin(userLogin);
            if(user == null) 
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
