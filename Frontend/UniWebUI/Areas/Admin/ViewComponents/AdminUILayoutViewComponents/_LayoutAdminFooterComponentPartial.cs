using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Areas.Admin.ViewComponents.AdminUILayoutViewComponents
{
    public class _LayoutAdminFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
