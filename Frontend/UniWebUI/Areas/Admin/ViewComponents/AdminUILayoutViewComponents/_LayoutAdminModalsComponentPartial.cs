﻿using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.Areas.Admin.ViewComponents.AdminUILayoutViewComponents
{
    public class _LayoutAdminModalsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
