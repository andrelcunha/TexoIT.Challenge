﻿using TEXOit.Core.Extensions;
using TEXOit.Data;
using TEXOit.Data.Repository;
using TEXOit.Services;

namespace TEXOit.Challenge.MovieAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<CsvService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<MovieContext>();

        }
    }
}
