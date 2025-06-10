using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using UniDto.AnswerDtos;
using UniDto.QuestionDtos;
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
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Users/GetByIdUser?id=" + id);
            ViewBag.UserId = id;
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetUserProfileDto>(jsonData);
                return View(result);

            }
            return View(new GetUserProfileDto());
        }
        public async Task<IActionResult> PublicProfile(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Users/GetByIdUser?id=" + id);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetUserProfileDto>(json);
                ViewBag.UserId = id;
                return View(result);
            }

            return View(new GetUserProfileDto());
        }

        public async Task<IActionResult> MyQuestions()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            ViewBag.UserId = userId;
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Questions/MyQuestions?userId=" + userId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetMyAllQuestionDto>>(jsonData);
                return View(result);

            }
            return View(new List<GetMyAllQuestionDto>());
        }
        public async Task<IActionResult> MyLikedQuestions()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            ViewBag.UserId = userId;
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Questions/MyLikedQuestions?userId=" + userId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetMyAllLikedQuestionDto>>(jsonData);
                return View(result);

            }
            return View(new List<GetMyAllLikedQuestionDto>());
        }
        public async Task<IActionResult> MyAnswers()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            ViewBag.UserId = userId;
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Answer/MyAnswer?userId=" + userId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetMyAllAnswerDto>>(jsonData);
                return View(result);

            }
            return View(new List<GetMyAllAnswerDto>());
        }
    }
}
