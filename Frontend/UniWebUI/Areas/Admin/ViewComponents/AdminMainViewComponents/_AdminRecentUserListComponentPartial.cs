using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.UserDtos;

namespace UniWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _AdminRecentUserListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminRecentUserListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = 3;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Users/RecentVerifiedUsers?count="+count);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetRecentUserDto>>(jsonData);
                return View(result);
            }
            return View(new GetRecentUserDto());
        }
    }
}
