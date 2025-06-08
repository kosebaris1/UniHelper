using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UniDto.RegisterDtos;
using UniDto.UniversityDtos;
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
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/GetAllUniversity");


            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var universities = JsonConvert.DeserializeObject<List<GetAllUniversityDto>>(jsonData);

                ViewBag.Universities = universities; // 📌 Burası eksikti
            }
            else
            {
                ViewBag.Universities = new List<GetAllUniversityDto>(); // fallback boş liste
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(CreateRegisterDto model)
        {
            var client = _httpClientFactory.CreateClient();

            using var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(model.FullName ?? ""), "FullName");
            formData.Add(new StringContent(model.Email ?? ""), "Email");
            formData.Add(new StringContent(model.PasswordHash ?? ""), "PasswordHash");
            formData.Add(new StringContent(model.PasswordConfirm ?? ""), "PasswordConfirm");
            formData.Add(new StringContent(model.StudentNumber ?? ""), "StudentNumber");

            formData.Add(new StringContent(model.UniversityId?.ToString() ?? ""), "UniversityId");
            formData.Add(new StringContent(model.DepartmentId?.ToString() ?? ""), "DepartmentId");

            // Dosyalar
            if (model.ProfilePictureUrl != null && model.ProfilePictureUrl.Length > 0)
            {
                var streamContent = new StreamContent(model.ProfilePictureUrl.OpenReadStream());
                formData.Add(streamContent, "ProfilePictureUrl", model.ProfilePictureUrl.FileName);
            }

            if (model.VerificationDocumentPath != null && model.VerificationDocumentPath.Length > 0)
            {
                var streamContent = new StreamContent(model.VerificationDocumentPath.OpenReadStream());
                formData.Add(streamContent, "VerificationDocumentPath", model.VerificationDocumentPath.FileName);
            }

            var response = await client.PostAsync("https://localhost:7224/api/Users/CreateUser", formData);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(model);
        }




    }
}

