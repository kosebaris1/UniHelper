using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.ViewComponents.UILayoutViewComponent
{
    public class _UILayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
