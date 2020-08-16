using HealthCare020.API.Properties;
using HealthCare020.Repository;
using HealthCare020.Repository.Data;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace HealthCare020.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<HealthCare020DbContext>();
                var cognitiveService = scope.ServiceProvider.GetRequiredService<IFaceRecognitionService>();
                if (DataSeed.Seed(service))
                {
                    Task.Run(async () =>
                    {
                        await cognitiveService.DeletePersonGroup(Resources.FaceAPI_PersonGroupId);
                    }).Wait();
                    Task.Run(async () =>
                    {
                        await cognitiveService.CreatePersonGroup(Resources.FaceAPI_PersonGroupId,
                            Resources.FaceAPI_PersonGroupName);
                    }).Wait();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => { config.AddEnvironmentVariables(); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}