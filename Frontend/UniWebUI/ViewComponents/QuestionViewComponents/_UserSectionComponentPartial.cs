using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.UserDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _UserSectionComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserSectionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Users/GetByIdUser?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetUserSectionDto>(jsonData);
                return View(result);
            }
            return View(new GetUserSectionDto());
        } 
    }
}
