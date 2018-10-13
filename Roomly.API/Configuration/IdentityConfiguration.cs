using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Roomly.API.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.ApiName = configuration["roomly:api:clientname"];
            //        options.ApiSecret = configuration["roomly:api:clientsecret"];
            //    });
            return services;
        }

        public static IApplicationBuilder RegisterIdentity(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            return app;
        }
    }
}
