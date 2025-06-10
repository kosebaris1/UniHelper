using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniDto.UserDtos;
using HayvanWebUI.Models;

namespace UniWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LoginController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        //burası token ile bağlanacak
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Users", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();

                // Bu satırı kontrol için logla
                Console.WriteLine("Gelen JSON:");
                Console.WriteLine(responseContent);

                try
                {
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDto>(responseContent);
                    var tokenString = tokenResponse.Token;

                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenString);

                    var expClaim = token.Claims.FirstOrDefault(c => c.Type == "exp");
                    DateTime expires = (expClaim != null && long.TryParse(expClaim.Value, out long unixExp))
                        ? DateTimeOffset.FromUnixTimeSeconds(unixExp).UtcDateTime
                        : DateTime.UtcNow.AddMinutes(30);

                    var claims = token.Claims.ToList();
                    claims.Add(new Claim("accessToken", tokenString));

                    var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = expires
                    };

                    await HttpContext.SignInAsync(
                        JwtBearerDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),
                        authProps);

                    return RedirectToAction("Index", "Main");
                }
                catch (JsonException)
                {
                    ViewBag.PasswordError = "1"; // Şifre hatası için kullanabilirsin
                    return View();
                }
            }
            else
            {
                // API başarısız olduysa
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine("API'den dönen hata mesajı: " + errorContent);

                ViewBag.PasswordError = "1";
                return View();
            }

        }
    }
}
