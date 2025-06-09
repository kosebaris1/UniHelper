﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Text;
using UniDto.DepartmenDtos;
using UniDto.QuestionDtos;
using UniDto.UniversityDtos;
using UniWebUI.Models;

namespace UniWebUI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? cityId = null, int? universityId = null, int? departmentId = null, List<int>? tagsId = null, string sortBy = "new")
        {
            var client = _httpClientFactory.CreateClient();
            var queryParams = new List<string>();

            if (cityId.HasValue)
                queryParams.Add($"CityId={cityId}");
            if (universityId.HasValue)
                queryParams.Add($"UniversityId={universityId}");
            if (departmentId.HasValue)
                queryParams.Add($"DepartmentId={departmentId}");
            if (tagsId != null && tagsId.Any())
            {
                foreach (var tagId in tagsId)
                {
                    queryParams.Add($"TagsId={tagId}");
                }
            }

            queryParams.Add($"SortBy={sortBy}"); // yeni parametre

            var queryString = "?" + string.Join("&", queryParams);

            var responseMessage = await client.GetAsync("https://localhost:7224/api/Questions" + queryString);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var questionList = JsonConvert.DeserializeObject<List<GetFilteredQuestionDto>>(jsonData);

                var viewModel = new QuestionListViewModel
                {
                    Questions = questionList,
                    SelectedCityId = cityId,
                    SelectedUniversityId = universityId,
                    SelectedDepartmentId = departmentId,
                    SelectedTagsId = tagsId,
                    SortBy = sortBy // set et
                };

                return View(viewModel);
            }

            return View(new QuestionListViewModel
            {
                Questions = new List<GetFilteredQuestionDto>(),
                SelectedCityId = cityId,
                SelectedUniversityId = universityId,
                SelectedDepartmentId = departmentId,
                SelectedTagsId = tagsId,
                SortBy = sortBy
            });
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // 🔹 Soru detayını al
            var response = await client.GetAsync($"https://localhost:7224/api/Questions/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound("Soru bulunamadı.");

            var json = await response.Content.ReadAsStringAsync();
            var viewModel = JsonConvert.DeserializeObject<QuestionDetailViewModel>(json); // 👈 Direkt ViewModel'e deserialize

            // 🔹 Giriş yapmış kullanıcıyı al
            int userId = 0;
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            }
            viewModel.CurrentUserId = userId;

            // 🔹 Cevap yazma yetkisi kontrolü
            var permissionResponse = await client.GetAsync($"https://localhost:7224/api/Answer/can-answer?userId={userId}&questionId={id}");
            if (permissionResponse.IsSuccessStatusCode)
            {
                var permissionJson = await permissionResponse.Content.ReadAsStringAsync();
                viewModel.CanAnswer = JsonConvert.DeserializeObject<bool>(permissionJson);
            }

            return View(viewModel);
        }




        [HttpGet]
        public async Task<IActionResult> CreateQuestion()
        {
            var client = _httpClientFactory.CreateClient();

            var uniResponse = await client.GetAsync("https://localhost:7224/GetAllUniversity");
            var deptResponse = await client.GetAsync("https://localhost:7224/GetAllDistinctDepartment");

            if (uniResponse.IsSuccessStatusCode && deptResponse.IsSuccessStatusCode)
            {
                var uniData = JsonConvert.DeserializeObject<List<GetAllUniversityDto>>(await uniResponse.Content.ReadAsStringAsync());
                var deptData = JsonConvert.DeserializeObject<List<GetAllDistinctDepartmentDto>>(await deptResponse.Content.ReadAsStringAsync());

                ViewBag.Universities = new SelectList(uniData, "UniversityId", "Name");
                ViewBag.Departments = new SelectList(deptData, "DepartmentId", "Name");
            }

            return View(new CreateQuestionDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            model.UserId = userId;

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7224/api/Questions", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Soru gönderilemedi. Lütfen tekrar deneyin.");
            return View();
        }

    }
}
