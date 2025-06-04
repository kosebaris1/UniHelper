using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.CityDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _CityFilterDropdownComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CityFilterDropdownComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedCityId = null)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Cities");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var cities = JsonConvert.DeserializeObject<List<GetAllCityDto>>(json);

                ViewBag.SelectedCityId = selectedCityId;
                return View(cities);
            }

            return View(new List<GetAllCityDto>());
        }
    }
}
