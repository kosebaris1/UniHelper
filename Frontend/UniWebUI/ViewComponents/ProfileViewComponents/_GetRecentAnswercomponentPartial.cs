using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.AnswerDtos;
using UniDto.UserDtos;

namespace UniWebUI.ViewComponents.ProfileViewComponents
{
    public class _GetRecentAnswercomponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetRecentAnswercomponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            int count = 3;
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync($"https://localhost:7224/api/Answer/RecentAnswer?userId={id}&count={count}");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetRecentAnswerDto>>(jsonData);
                return View(result);

            }
            return View(new List<GetUserProfileDto>());
        }
    }
}
