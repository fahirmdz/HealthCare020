using System.Linq;
using HealthCare020.Repository;
using HealthCare020.Services.Configuration;
using HealthCare020.Services.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace HealthCare020.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HealthCare020DbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging(true));

            services.AddSwaggerGen(x =>
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthCare020 API", Version = "v1" }));

            services.TryAddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            services.AddHealthCare020Services();

            services.AddControllers(cfg =>
                {
                    cfg.Filters.Add(typeof(ErrorFilter));
                    cfg.ReturnHttpNotAcceptable = true;
                }).AddNewtonsoftJson(setupAction =>
                  {
                    //Input and output JSON formatters

                   setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                  }).AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(config =>
                {
                    config.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "Model state validation error",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Title = "One or more validation errors occurred",
                            Detail = "See the errors field for details.",
                            Instance = context.HttpContext.Request.Path
                        };

                        problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = {"application/problem+json"}
                        };
                    };
                });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthCare020 API v1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}