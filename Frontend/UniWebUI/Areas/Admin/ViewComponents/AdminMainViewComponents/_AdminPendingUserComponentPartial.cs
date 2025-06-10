using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.QuestionDtos;
using UniDto.UserDtos;

namespace UniWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _AdminPendingUserComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminPendingUserComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Users/AllUnverifiedUser");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllPendingUserDto>>(jsonData);
                return View(result);
            }
            return View(new GetAllPendingUserDto());
        }
    }
}
