using QPDTask.Service;
using AutoMapper;

namespace QPDTask.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddService(configuration);
        }
        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("qpdtask."));

            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}
