using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string role)
        {
            if (role == "User")
            {
                return View("User");
            }
            else if(role == "Redactor")
            {
                return View("Redactor");
            }
            else
            {
                return View("Admin");
            }
        }
    }
}
