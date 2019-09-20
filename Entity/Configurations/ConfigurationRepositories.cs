using Entity.Repositories;
using Entity.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Configurations
{
    public static class ConfigurationRepositories
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWrapperRepository, WrapperRepository>();
        }
    }
}
