using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.QuestionDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _GetAnswerComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetAnswerComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int questionId, int currentUserId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7224/api/Answer/AllAnswerByQuestion?questionId={questionId}&currentUserId={currentUserId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAnswerDto>>(jsonData);
                return View(result);
            }

            return View(new List<GetAnswerDto>());
        }
    }
}
