using Healthcare020.OAuth.Configuration;
using Healthcare020.OAuth.Services;
using Healthcare020.OAuth.Validators;
using HealthCare020.Repository;
using HealthCare020.Services.Configuration;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddDbContext<HealthCare020DbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging(true));

            var cors = new DefaultCorsPolicyService(new Logger<DefaultCorsPolicyService>(new LoggerFactory()))
            {
                AllowedOrigins = { "https://localhost:5001" }
            };
            services.AddSingleton<ICorsPolicyService>(cors);

            services.AddIdentityServer()
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>();

            services.AddHealthCare020Services();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }
    }
}