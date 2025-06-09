//using HayvanDto.PetTypeDtos;
//using HayvanDto.UserDtos;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

//namespace HayvanWebUI.Areas.Admin.ViewComponents.AdminMainViewComponents
//{
//    public class _AdminStatsCardComponentPartial:ViewComponent
//    {
//        private readonly IHttpClientFactory _httpClientFactory;

//        public _AdminStatsCardComponentPartial(IHttpClientFactory httpClientFactory)
//        {
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var client = _httpClientFactory.CreateClient();
//            var responseMessage = await client.GetAsync("https://localhost:7160/api/Auths/AdminDashboardStats");
//            if (responseMessage.IsSuccessStatusCode)
//            {
//                var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<GetAdminStatsDto>(jsonData);
//                return View(result);
//            }
//            return View(new GetAdminStatsDto());
//        }
//    }
//}
