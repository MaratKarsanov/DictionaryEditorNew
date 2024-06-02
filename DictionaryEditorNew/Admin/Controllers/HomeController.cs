using Microsoft.AspNetCore.Mvc;
using DictionaryEditorDbNew;
using DictionaryEditorDbNew.Models;


namespace DictionaryEditorNew.Admin.Controllers
{
    public class HomeController : Controller
    {
        private RoleDbRepository roleRepository;
        private UserDbRepository userRepository;
        public HomeController(RoleDbRepository roleRepository,
            UserDbRepository userRepository)
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
                roleRepository.Add(new DictionaryEditorDbNew.Models.Role() { Name = "User" });
                roleRepository.Add(new DictionaryEditorDbNew.Models.Role() { Name = "Admin" });
                roleRepository.Add(new DictionaryEditorDbNew.Models.Role() { Name = "Redactor" });
            }
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
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
