using SignPLAPI.Common;
using SignPLAPI.Service;

namespace SignPLAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<JwtService>();
            return services;
        }
    }
}
