using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Views.Shared.Components.Navbar
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(dynamic viewBagNavbarType)
        {
            if (viewBagNavbarType == null)
            {
                return View("UnLoginUser");
            }
            else if (viewBagNavbarType == "User")
            {
                return View("User");
            }
            else if(viewBagNavbarType == "Redactor")
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
