using Microsoft.AspNetCore.Mvc;

namespace UniWebUI.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
