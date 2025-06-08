using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.TagDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _CreateQuestionTagFilterMultiSelectComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CreateQuestionTagFilterMultiSelectComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<int>? selectedTagIds)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Tags/AllTag");

            if (!response.IsSuccessStatusCode)
                return View(new List<GetAllTagDto>());

            var json = await response.Content.ReadAsStringAsync();
            var tags = JsonConvert.DeserializeObject<List<GetAllTagDto>>(json) ?? new();

            ViewBag.SelectedTagIds = selectedTagIds ?? new List<int>();
            return View(tags);
        }
    }
}
