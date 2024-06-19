using DictionaryEditorDbNew;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Views.Shared.Components.Admin
{
    public class AdminViewComponent : ViewComponent
    {
        private UserDbRepository userRepository;
        public AdminViewComponent(UserDbRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IViewComponentResult Invoke()
        {
            var userLogin = HttpContext.Request.Cookies["userLogin"];
            var user = userRepository.TryGetByLogin(userLogin);
            if (user == null)
                return View("Admin", false);
            var userRole = user.Role.Name;
            return View("Admin", user.Role.Name == "Admin");
        }
    }
}
