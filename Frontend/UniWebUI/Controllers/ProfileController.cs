using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.UserDtos;

namespace UniWebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Users/GetByIdUser?id="+id);
            ViewBag.UserId = id;
            if(reponseMessage.IsSuccessStatusCode)
            {
                var jsonData= await reponseMessage.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<GetUserProfileDto>(jsonData);
                return View(result);

            }
            return View(new GetUserProfileDto());
        }
    }
}
