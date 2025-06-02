using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.RegisterDto;

namespace UniWebUI.ViewComponents.RegisterViewComponents
{
    public class _RegisterDepartmentComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _RegisterDepartmentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/GetDepartmentsByUniversity?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetDepartmentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
