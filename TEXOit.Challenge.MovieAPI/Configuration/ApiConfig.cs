﻿using Microsoft.Extensions.Options;
using TEXOit.Core.Extensions;
using TEXOit.Services;
using Microsoft.EntityFrameworkCore.Sqlite;
using TEXOit.Data;
using Microsoft.EntityFrameworkCore;

namespace TEXOit.Challenge.MovieAPI.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);

            var connection = configuration.GetSection("DefaultConnection").Value;
            services.AddDbContext<MovieContext>(options =>
                options.UseSqlite(connection)
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

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
