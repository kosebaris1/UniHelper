using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
