using Application.Interfaces.GptSummaryInterface;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.GptSummaryRepository;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient(); // HttpClient için
            services.AddScoped<IGeminiSummaryService, GeminiSummaryService>(); // GPT servisini ekliyoruz

            return services;
        }
    }
}
