using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UniWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            ViewBag.UserId = userId;
            return View();
        }
    }
}
