﻿using Microsoft.EntityFrameworkCore;
using TEXOit.Challenge.MovieAPI.Services;
using TEXOit.Core.Extensions;
using TEXOit.Data;

namespace TEXOit.Challenge.MovieAPI.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MovieContext>(options =>
                options.UseSqlite("name=DefaultConnection")
            );

            services.AddControllers();

            services.AddEndpointsApiExplorer();

        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwaggerConfiguration();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.InitializeDb();
        }

        private static void InitializeDb(this IApplicationBuilder app)
        {
            File.Delete("MoviesDB.db");
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
            db.Database.Migrate();

            var populateDb = scope.ServiceProvider.GetRequiredService<IPopulateDb>();
            populateDb.ImpotCsvData();
        }
    }
}
