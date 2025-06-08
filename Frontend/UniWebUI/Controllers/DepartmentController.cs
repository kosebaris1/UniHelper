using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.DepartmenDtos;

namespace UniWebUI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/GetDepartmentsByUniversity?id="+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetDepartmentByUniDto>>(jsonData);
                return Json(result); 

            }
            return View(new List<GetDepartmentByUniDto>());
        }
    }
}
