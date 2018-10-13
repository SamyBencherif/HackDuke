using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roomly.Data.Repositories;

namespace Roomly.Data.Configuration
{
    public static class DataConfiguration
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            return services.ConfigureDatabase(configuration);
        }

        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RoomlyContext>(options => options.UseSqlServer(configuration.GetConnectionString("RoomlyDbConnection")));
            var context = services.GetService<RoomlyContext>();
            context.Database.Migrate();

            return services;
        }

        private static TType GetService<TType>(this IServiceCollection services)
        {
            var temporaryProvider = services.BuildServiceProvider();
            var service = temporaryProvider.GetService<TType>();
            return service;
        }
    }
}
