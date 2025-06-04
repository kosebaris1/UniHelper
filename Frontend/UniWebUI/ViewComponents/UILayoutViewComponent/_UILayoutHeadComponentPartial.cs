using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.ViewComponents.UILayoutViewComponent
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
