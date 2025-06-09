//using HayvanDto.PetDtos;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

//namespace HayvanWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
//{
//    public class _AdminRecentListComponentPartial:ViewComponent
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public _AdminRecentListComponentPartial(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var client= _httpClientFactory.CreateClient();
//            var responseMessage = await client.GetAsync("https://localhost:7160/api/Pets/LastPets?count=5");
//            if(responseMessage.IsSuccessStatusCode)
//            {
//                var jsonData= await responseMessage.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<List<GetLastPetsDto>>(jsonData);
//                return View(result);
//            }
//            return View(new GetLastPetsDto());
//        }
//    }
//}
