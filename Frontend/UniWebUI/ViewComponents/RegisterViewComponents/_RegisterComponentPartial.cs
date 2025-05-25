
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.RegisterDto;

namespace UniWebUI.ViewComponents.RegisterViewComponents
{
    public class _RegisterComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RegisterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        { 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/GetAllUniversity");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<GetUniversityDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
