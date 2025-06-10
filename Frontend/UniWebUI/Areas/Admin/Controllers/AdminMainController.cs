using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UniWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminMain")]
    //[Authorize(Roles = "Admin")]
    public class AdminMainController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMainController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Accept")]
        [HttpPost]
        public async Task<IActionResult> Accept(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var dto = new { QuestionId = id };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7224/api/Questions/approve", content);

            return RedirectToAction("Index", "AdminMain", new { area = "Admin" }); // veya View() vs
        }
        [Route("Reject")]
        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var dto = new { QuestionId = id };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7224/api/Questions/reject", content);

            return RedirectToAction("Index", "AdminMain", new { area = "Admin" }); // veya View() vs
        }
        [HttpPost]
        public async Task<IActionResult> ApproveUser(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var dto = new { UserId = id };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7224/api/Users/Accept", content);

            return RedirectToAction("Index", "AdminMain", new { area = "Admin" }); // veya View() vs
        }
    }
}
