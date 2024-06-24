using AutoMapper;
using DictionaryEditorDbNew.Repositories;
using DictionaryEditorNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserDbRepository userRepository;
        private IMapper mapper;
        public UserController(UserDbRepository userRepository,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(mapper.Map<List<UserViewModel>>(userRepository.GetAll()));
        }
        //public IActionResult Edit(string login)
        //{
        //    var user = userRepository.TryGetByLogin(login);
        //    return View(mapper.Map<UserViewModel>(user));
        //}
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

        //[HttpGet]
        //public IActionResult ChangePassword(string login)
        //{
        //    ViewData["login"] = login;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult ChangePassword(ChangeUserPasswordViewModel password, string login)
        //{
        //    if (!ModelState.IsValid)
        //        return RedirectToAction(nameof(ChangePassword));
        //    var user = userManager.FindByNameAsync(login).Result;
        //    var newHashPassword = userManager.PasswordHasher.HashPassword(user, password.NewPassword);
        //    user.PasswordHash = newHashPassword;
        //    userManager.UpdateAsync(user).Wait();
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public IActionResult ChangeRole(string login)
        //{
        //    var user = userManager.FindByNameAsync(login).Result;
        //    var userRoles = userManager.GetRolesAsync(user).Result;
        //    var roles = roleManager.Roles;
        //    ViewData["login"] = user.UserName;
        //    ViewBag.userRoles = userRoles.ToHashSet();
        //    return View(mapper.Map<List<RoleViewModel>>(roles));
        //}

        //[HttpPost]
        //public IActionResult ChangeRole(Dictionary<string, bool> userRolesViewModels, string login)
        //{
        //    if (!ModelState.IsValid)
        //        return View();
        //    var selectedRoles = userRolesViewModels.Select(x => x.Key);
        //    var user = userManager.FindByNameAsync(login).Result;
        //    var userRoles = userManager.GetRolesAsync(user).Result;
        //    userManager.RemoveFromRolesAsync(user, userRoles).Wait();
        //    userManager.AddToRolesAsync(user, selectedRoles).Wait();
        //    if (login == User.Identity.Name && !userRolesViewModels.ContainsKey("Administrator"))
        //        return RedirectToAction("Index", "Home", new { area = "" });
        //    return RedirectToAction(nameof(Edit), new { login });
        //}

        //public IActionResult Delete(string login)
        //{
        //    var user = userManager.FindByNameAsync(login).Result;
        //    userManager.DeleteAsync(user).Wait();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
