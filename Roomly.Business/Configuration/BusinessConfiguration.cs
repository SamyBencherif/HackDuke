using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Roomly.Business.Configuration
{
    public static class BusinessConfiguration
    {
        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionService>();

            return services;
        }
    }
}
