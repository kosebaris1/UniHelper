using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
