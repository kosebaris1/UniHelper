using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.UserDtos;

namespace UniWebUI.ViewComponents.ProfileViewComponents
{
    public class _ProfileSideBarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProfileSideBarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Users/GetByIdUser?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetUserProfileDto>(jsonData);
                return View(result);

            }
            return View(new GetUserProfileDto());
        }
    }
}
