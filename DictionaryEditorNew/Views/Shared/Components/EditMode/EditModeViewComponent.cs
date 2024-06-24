using Microsoft.AspNetCore.Mvc;

namespace DictionaryEditorNew.Views.Shared.Components.EditMode
{
    public class EditModeViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string role)
        {
            return View();
        }
    }
}
