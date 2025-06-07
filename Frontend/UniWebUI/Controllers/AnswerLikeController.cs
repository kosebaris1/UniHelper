using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace UniWebUI.Controllers
{
    public class AnswerLikeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AnswerLikeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpPost]
        public async Task<IActionResult> Like(int userId, int answerId)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(new { UserId = userId, AnswerId = answerId });
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7224/api/AnswerLikes", content);
            if (response.IsSuccessStatusCode)
                return Json(new { success = true });

            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> UnLike(int userId, int answerId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7224/api/AnswerLikes?userId={userId}&answerId={answerId}");

            if (response.IsSuccessStatusCode)
                return Json(new { success = true });

            return Json(new { success = false });
        }

        
    }
}
