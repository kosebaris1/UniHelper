using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.DepartmenDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _DepartmentFilterDropdownComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DepartmentFilterDropdownComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? selectedDepartmentId = null)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/GetAllDistinctDepartment");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var departments = JsonConvert.DeserializeObject<List<GetAllDistinctDepartmentDto>>(json);

                ViewBag.SelectedDepartmentId = selectedDepartmentId;
                return View(departments);
            }

            return View(new List<GetAllDistinctDepartmentDto>());
        }
    }
}
