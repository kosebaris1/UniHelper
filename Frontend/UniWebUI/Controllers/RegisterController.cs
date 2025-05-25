using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UniDto.RegisterDto;
using UniWebUI.Models;

namespace UniWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateRegisterDto model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7224/api/Users/CreateUser", stringContent);
            Console.WriteLine("Gelen DTO: " + JsonConvert.SerializeObject(model));
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }



    }
}

