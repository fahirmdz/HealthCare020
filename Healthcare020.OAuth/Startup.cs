using Healthcare020.LoggerService.Configuration;
using Healthcare020.LoggerService.Interfaces;
using Healthcare020.OAuth.Configuration;
using Healthcare020.OAuth.Extensions;
using Healthcare020.OAuth.Properties;
using Healthcare020.OAuth.Services;
using Healthcare020.OAuth.Validators;
using HealthCare020.Core.Constants;
using HealthCare020.Repository;
using HealthCare020.Services.Configuration;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace Healthcare020.OAuth
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Environment = env;
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLoggerService();
            services.AddDbContext<HealthCare020DbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("Healthcare020")).EnableSensitiveDataLogging(true));

            services.AddIdentityServer(opt =>
                {
                    opt.IssuerUri = Resources.ProductionUri;
                    opt.Discovery.CustomEntries.Add("face-recognition", $"~/{Routes.FaceRecognitionRoute}");
                })
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddInMemoryApiResources(InMemoryConfig.Apis)
                .AddDeveloperSigningCredential()
                .AddCorsPolicyService<InMemoryCorsPolicyService>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>();

            services.AddHealthCare020Services(Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseRouting();
            app.ConfigureExceptionHandler(logger);

            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}