using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using UniDto.QuestionDtos;

namespace UniWebUI.Controllers
{
    public class QuestionCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int questionId, string commentText)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdStr, out var userId))
                return Json(new { success = false });

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(new
            {
                UserId = userId,
                QuestionId = questionId,
                Content = commentText
            });

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7224/api/Answer", content);

            if (response.IsSuccessStatusCode)
            {
                var userName = User.Identity?.Name ?? "Kullanıcı";
                return RedirectToAction("Detail", "Question", new { id = questionId });
            }

            return Json(new { success = false });
        }

        [HttpGet]
        public async Task<IActionResult> CommentsPartial(int questionId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7224/api/Answer/AllAnswerByQuestion?questionId={questionId}");

            if (!response.IsSuccessStatusCode)
                return PartialView("_CommentsPartial", new List<GetAnswerDto>());

            var jsonData = await response.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<GetAnswerDto>>(jsonData);

            return PartialView("_CommentsPartial", comments);
        }


    }
}
