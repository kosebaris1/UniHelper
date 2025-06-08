using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.UniversityDtos;

namespace UniWebUI.ViewComponents.RegisterViewComponents
{
    public class _UniversitiesDropdownComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UniversitiesDropdownComponentPartial(IHttpClientFactory httpClientFactory)
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
                var result = JsonConvert.DeserializeObject<List<GetAllUniversityDto>>(jsonData);
                return View(result);
            }
            return View(new List<GetAllUniversityDto>());
        } 
    }
}
