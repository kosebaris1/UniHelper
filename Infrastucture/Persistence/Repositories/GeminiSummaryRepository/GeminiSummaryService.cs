using Application.Interfaces.GptSummaryInterface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Persistence.Repositories.GptSummaryRepository
{
    public class GeminiSummaryService : IGeminiSummaryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiSummaryService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://generativelanguage.googleapis.com/");
            _apiKey = configuration["GeminiApi:Key"];
        }

        public async Task<string> GetSummaryAsync(List<string> answers)
        {
            var prompt = @"Aşağıda bir üniversite hakkında yapılmış yorumlar yer alıyor. Bu yorumları okuyarak, öğrencilerin genel olarak okul hakkında ne düşündüğünü özetle. Belirli cevaplara doğrudan referans verme, sadece ortak düşünceleri sade bir dille ifade et.";
            for (int i = 0; i < answers.Count; i++)
            {
                prompt += $"{i + 1}. {answers[i]}\n";
            }

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(
    $"v1/models/gemini-1.5-flash:generateContent?key={_apiKey}", content);


            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return $"Gemini Hata: {error}";
            }

            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);

            var root = doc.RootElement;
            var candidates = root.GetProperty("candidates");
            var first = candidates[0];
            var contentText = first
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return contentText;
        }
    }
}
