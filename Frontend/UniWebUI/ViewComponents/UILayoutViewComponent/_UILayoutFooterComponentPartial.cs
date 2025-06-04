using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.ViewComponents.UILayoutViewComponent
{
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
