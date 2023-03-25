using TEXOit.Challenge.MovieAPI.Extensions;

namespace TEXOit.Challenge.MovieAPI.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
        }
    }
}
