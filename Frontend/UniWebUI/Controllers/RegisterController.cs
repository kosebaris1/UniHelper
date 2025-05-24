using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
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
            var model = new RegisterViewModel
            {
                Universities =await GetUniversityListAsync(),
                Departments =await GetDepartmentListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            model.Universities =await GetUniversityListAsync();
            model.Departments =await GetDepartmentListAsync();

            //if (fakeRegisteredEmails.Contains(model.Email.ToLower()))
            //{
            //    model.IsEmailTaken = true;
            //    ModelState.AddModelError("Email", "Bu mail zaten alınmış");
            //    return View(model);
            //}

            if (ModelState.IsValid)
            {
                if (model.StudentDocument != null && model.StudentDocument.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/student_docs");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.StudentDocument.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.StudentDocument.CopyToAsync(stream);
                    }
                }

                return RedirectToAction("Success");
            }

            return View(model);
        }

        private async Task<List<string>> GetUniversityListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var universities = await client.GetFromJsonAsync<List<string>>("https://yourapi.com/api/universities");
            return universities ?? new List<string>();
        }

        private async Task<List<string>> GetDepartmentListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var departments = await client.GetFromJsonAsync<List<string>>("https://yourapi.com/api/departments");
            return departments ?? new List<string>();
        }

        public IActionResult Success()
        {
            return Content("Kayıt başarılı!");
        }
    }
}

