using Healthcare020.LoggerService.Configuration;
using Healthcare020.LoggerService.Interfaces;
using Healthcare020.LoggerService.Services;
using HealthCare020.API.Configuration;
using HealthCare020.API.Constants;
using HealthCare020.API.Extensions;
using HealthCare020.Repository;
using HealthCare020.Services.Configuration;
using HealthCare020.Services.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace HealthCare020.API
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
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging());

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HealthCare020 API",
                    Version = "v1"
                });

                x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(Environment.IsDevelopment() ? "https://localhost:5007/connect/authorize"
                                : "https://healthcare020-oauth.com:5005/connect/authorize"),

                            TokenUrl = new Uri(Environment.IsDevelopment() ? "https://localhost:5007/connect/token"
                                : "https://healthcare020-oauth.com:5005/connect/token")
                        }
                    },
                    OpenIdConnectUrl = new Uri(Environment.IsDevelopment() ? "https://localhost:5007/.well-known/openid-configuration"
                        : "https://healthcare020-oauth.com:5005/.well-known/openid-configuration"),

                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "oauth2"}
                        },
                        new List<string>()
                    }
                });
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddHealthCare020Services(Configuration);
            services.AddDistributedMemoryCache();
            services.AddResponseCaching();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("bs-Latn-BA");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("bs-Latn-BA") };
            });

            services.AddAuthConfiguration(Environment);

            var logger = new LoggerManager();
            services.AddSession();
            services.AddControllers(cfg =>
                {
                    cfg.Filters.Add(typeof(ErrorFilter));
                    cfg.ReturnHttpNotAcceptable = true;
                    cfg.CacheProfiles.Add(CacheProfilesConstants.CacheProfile240Seconds, new CacheProfile { Duration = 240 });
                })
                .AddNewtonsoftJson(setupAction =>
                {
                    //Input and output JSON formatters
                    setupAction.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    setupAction.SerializerSettings.MaxDepth = 1;
                    setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(config =>
                {
                    config.InvalidModelStateResponseFactory = context =>
                    {
                        var detailsString = string.Empty;

                        foreach (var modelState in context.ModelState.Values)
                        {
                            foreach (var error in modelState.Errors)
                            {
                                detailsString += $"{error.ErrorMessage}\r\n";
                            }
                        }

                        var problemDetails = new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "Model state validation error",
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Title = "One or more validation errors occurred",
                            Detail = detailsString,
                            Instance = context.HttpContext.Request.Path
                        };

                        logger.LogInfo($"Model state errors details: {problemDetails.Detail}\n");

                        problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
            }

            app.ConfigureExceptionHandler(logger);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthCare020 API v1");
                c.OAuthClientId("Healthcare020_WebAPI");
                c.OAuthClientSecret("devsecret");
            });
            app.UseHttpsRedirection();
            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}