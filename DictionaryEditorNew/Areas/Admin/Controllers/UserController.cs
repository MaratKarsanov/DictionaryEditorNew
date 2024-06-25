using AutoMapper;
using DictionaryEditorDbNew.Models;
using DictionaryEditorDbNew.Repositories;
using DictionaryEditorNew.Areas.Admin.Models;
using DictionaryEditorNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserDbRepository userRepository;
        private RoleDbRepository roleRepository;
        private IMapper mapper;
        public UserController(UserDbRepository userRepository,
            IMapper mapper,
            RoleDbRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<List<UserViewModel>>(userRepository.GetAll()));
        }
        public IActionResult Edit(string login)
        {
            var user = userRepository.TryGetByLogin(login);
            return View(mapper.Map<UserViewModel>(user));
        }
        //[HttpGet]
        //public IActionResult EditData(string login)
        //{
        //    var user = userRepository.TryGetByLogin(login);
        //    var userData = new EditUserDataViewModel()
        //    {
        //        Login = user.Login,
        //        Name = user.Name,
        //        Surname = user.Surname
        //    };
        //    ViewData["login"] = login;
        //    return View(userData);
        //}

        //[HttpPost]
        //public IActionResult EditData(string login, EditUserDataViewModel newUserData)
        //{
        //    if (!ModelState.IsValid)
        //        return View(newUserData);
        //    var user = userRepository.TryGetByLogin(login);
        //    user.PhoneNumber = newUserData.PhoneNumber;
        //    user.UserName = newUserData.UserName;
        //    return RedirectToAction(nameof(Edit), new { login });
        //}

        [HttpGet]
        public IActionResult ChangePassword(string login)
        {
            ViewData["login"] = login;
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangeUserPasswordViewModel password, string login)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ChangePassword));
            userRepository.ChangePassword(login, password.NewPassword);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeRole(string login)
        {
            var user = userRepository.TryGetByLogin(login);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            ViewData["login"] = user.Login;
            ViewData["roleName"] = user.Role.Name;
            return View(roleRepository
                .GetAll()
                .Where(r => r.Name != user.Role.Name)
                .Select(mapper.Map<RoleViewModel>));
        }

        [HttpPost]
        public IActionResult ChangeRole(Role newRole, string login)
        {
            if (!ModelState.IsValid)
                return View();
            userRepository.ChangeRole(login, newRole.Name);
            return RedirectToAction(nameof(Edit), new { login });
        }

        //public IActionResult Delete(string login)
        //{
        //    var user = userManager.FindByNameAsync(login).Result;
        //    userManager.DeleteAsync(user).Wait();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
