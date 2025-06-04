using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.ViewComponents.UILayoutViewComponent
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
