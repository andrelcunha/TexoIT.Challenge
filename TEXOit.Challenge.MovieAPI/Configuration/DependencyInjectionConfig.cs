using TEXOit.Core.Extensions;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<CsvService>();

        }
    }
}
