using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.QuestionDtos;

namespace UniWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _AdminRecentQuestionListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminRecentQuestionListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Questions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetLastQuestionDto>>(jsonData);
                return View(result);
            }
            return View(new GetLastQuestionDto());
        }
    }
}
