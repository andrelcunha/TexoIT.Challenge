using TEXOit.Core.Extensions;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.AddSingleton<CsvService>();

        }
    }
}
