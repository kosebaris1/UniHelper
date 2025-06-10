using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.StatisticDtos;

namespace UniWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
{
    public class _AdminStatsCardComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminStatsCardComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Statistics/dashboard");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetStatisticsDto>(jsonData);
                return View(result);
            }
            return View(new GetStatisticsDto());
        }
    }
}
