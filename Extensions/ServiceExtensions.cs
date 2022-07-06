using DiffApi.Interfaces;
using DiffApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                                                           .AllowAnyOrigin()
                                                           .AllowAnyMethod()
                                                           .AllowAnyHeader()
                                                           .AllowCredentials());

            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureDataServices(this IServiceCollection services)
        {
            services.AddScoped<IHomeService, Home>();
            services.AddScoped<IDataService, DataService>((ctx) =>
            {
                IHomeService homeService = ctx.GetService<IHomeService>();
                return new DataService(homeService);

            });
        }
    }
}
