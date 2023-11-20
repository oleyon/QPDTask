using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using QPDTask.Service.Configuration;

namespace QPDTask.Service
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DadataConfig>((sp => new DadataConfig
            {
                ApiKey = configuration["DADATA_API_KEY"],
                ApiSecret = configuration["DADATA_API_SECRET"]
            }));
            services.AddHttpClient<DadataHttpClient>();
            services.AddSingleton<IDadataService, DadataService>();
            return services;
        }
    }
}