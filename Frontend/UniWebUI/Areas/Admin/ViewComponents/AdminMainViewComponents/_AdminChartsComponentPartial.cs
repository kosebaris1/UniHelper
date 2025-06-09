//using HayvanDto.PetTypeDtos;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

//namespace HayvanWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
//{
//    public class _AdminChartsComponentPartial:ViewComponent
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public _AdminChartsComponentPartial(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var client = _httpClientFactory.CreateClient();
//            var responseMessage = await client.GetAsync("https://localhost:7160/api/PetTypes/GetPetTypeCount");
//            if (responseMessage.IsSuccessStatusCode)
//            {
//                var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<List<GetPetTypeCountDto>>(jsonData);
//                return View(result);
//            }
//            return View(new GetPetTypeCountDto());
//        }
//    }
//}
