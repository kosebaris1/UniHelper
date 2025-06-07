using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UniWebUI.Controllers
{
    public class QuestionLikeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionLikeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Like(int userId, int questionId)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(new { UserId = userId, QuestionId = questionId });
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7224/api/QuestionLikes", content);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true });

            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> UnLike(int userId, int questionId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7224/api/QuestionLikes?userId={userId}&questionId={questionId}");

            if (response.IsSuccessStatusCode)
                return Json(new { success = true });

            return Json(new { success = false });
        }

        [HttpGet]
        public async Task<IActionResult> GetLikeCount(int questionId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7224/api/QuestionLikes?questionId={questionId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
            }

            return Json(new { likeCount = 0 });
        }
    }
}
