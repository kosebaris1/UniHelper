using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.ViewComponents.UILayoutViewComponent
{
    public class _UILayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
