using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.AnswerDtos;
using UniDto.UserDtos;

namespace UniWebUI.ViewComponents.MainViewComponents
{
    public class _GetBest3UserComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetBest3UserComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync($"https://localhost:7224/api/Users/Get3TopLikeUser");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetBest3UserDto>>(jsonData);
                return View(result);

            }
            return View(new List<GetBest3UserDto>());
        }
    }
}
