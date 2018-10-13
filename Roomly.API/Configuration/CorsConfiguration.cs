using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Roomly.API.Configuration
{
    public static class CorsConfiguration
    {
        private const string PolicyName = "Roomly.Cors";
        public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName,
                    builder => builder
                        // .WithOrigins("http://localhost:4200") //TODO: Get from appSettings
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Total-Count")
                        .AllowCredentials());
            });
            return services;
        }

        public static IApplicationBuilder RegisterCors(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }



    }
}
