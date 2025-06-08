using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.AnswerDtos;
using UniDto.QuestionDtos;
using UniDto.UserDtos;

namespace UniWebUI.ViewComponents.ProfileViewComponents
{
    public class _GetTopQuestionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetTopQuestionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            int count = 2;
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync($"https://localhost:7224/api/Questions/TopQuestion?userId={id}&count={count}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetTopQuestionDto>>(jsonData);
                return View(result);

            }
            return View(new List<GetTopQuestionDto>());
        }
    }
}
