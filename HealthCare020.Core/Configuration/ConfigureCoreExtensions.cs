using System;
using System.ComponentModel.Design;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare020.Core.Configuration
{
    public static class ConfigureCoreExtensions
    {
        public static void ConfigureHealthcare020Core(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}