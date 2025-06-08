using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UniDto.TagDtos;

namespace UniWebUI.ViewComponents.QuestionViewComponents
{
    public class _TagFilterMultiSelectComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TagFilterMultiSelectComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<int>? selectedTagIds = null)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Tags/AllTag");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tags = JsonConvert.DeserializeObject<List<GetAllTagDto>>(json);

                ViewBag.SelectedTagIds = selectedTagIds ?? new List<int>();
                return View(tags);
            }

            return View(new List<GetAllTagDto>());
        }
    }
}
