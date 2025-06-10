using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLayout")]
    //[Authorize(Roles = "Admin")]
    public class AdminLayoutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
