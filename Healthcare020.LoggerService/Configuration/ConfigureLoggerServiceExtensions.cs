using Healthcare020.LoggerService.Interfaces;
using Healthcare020.LoggerService.Services;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace Healthcare020.LoggerService.Configuration
{
    public static class ConfigureLoggerServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            LogManager.LoadConfiguration("nlog.config");
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}