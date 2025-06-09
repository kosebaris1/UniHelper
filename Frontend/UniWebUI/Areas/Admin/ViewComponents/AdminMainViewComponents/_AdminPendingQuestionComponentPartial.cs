using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.QuestionDtos;

namespace UniWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _AdminPendingQuestionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminPendingQuestionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Questions/PendingQuestions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllPendingQuestionDto>>(jsonData);
                return View(result);
            }
            return View(new GetAllPendingQuestionDto());
        }
    }
}
