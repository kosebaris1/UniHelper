using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using UniDto.QuestionDtos;
using UniWebUI.Models;

namespace UniWebUI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuestionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? cityId = null, int? universityId = null, int? departmentId = null, List<int>? tagsId = null)
        {
            var client = _httpClientFactory.CreateClient();

            var queryParams = new List<string>();

            if (cityId.HasValue)
                queryParams.Add($"CityId={cityId}");

            if (universityId.HasValue)
                queryParams.Add($"UniversityId={universityId}");

            if (departmentId.HasValue)
                queryParams.Add($"DepartmentId={departmentId}");

            if (tagsId != null && tagsId.Any())
            {
                foreach (var tagId in tagsId)
                {
                    queryParams.Add($"TagsId={tagId}");
                }
            }

            var queryString = queryParams.Any()
                ? "?" + string.Join("&", queryParams)
                : string.Empty;

            var responseMessage = await client.GetAsync("https://localhost:7224/api/Questions" + queryString);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var questionList = JsonConvert.DeserializeObject<List<GetFilteredQuestionDto>>(jsonData);

                var viewModel = new QuestionListViewModel
                {
                    Questions = questionList,
                    SelectedCityId = cityId,
                    SelectedUniversityId = universityId,
                    SelectedDepartmentId = departmentId,
                    SelectedTagsId = tagsId
                };

                return View(viewModel);
            }

            return View(new QuestionListViewModel
            {
                Questions = new List<GetFilteredQuestionDto>(),
                SelectedCityId = cityId,
                SelectedUniversityId = universityId,
                SelectedDepartmentId = departmentId,
                SelectedTagsId = tagsId
            });
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult CreateQuestion()
        {
            return View();
        }
    }
}
