using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.UniversityDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _UniversityFilterDropdownComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UniversityFilterDropdownComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedUniversityId = null)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/GetAllUniversity");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllUniversityDto>>(jsonData);

                ViewBag.SelectedUniversityId = selectedUniversityId;
                return View(result);
            }

            return View(new List<GetAllUniversityDto>());
        }
    }
}
