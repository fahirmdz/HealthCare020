using System.Linq;
using HealthCare020.API.Constants;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare020.API.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
        {
             services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:5005/";
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(AuthorizationPolicies.AdminPolicy, policy =>
                {
                    policy.RequireAssertion(context =>
                        {
                            var roles = context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

                            var listOfRoles = roles?.Split(",").ToList();

                            return listOfRoles?.Contains("Administrator") ?? false;
                        }
                    );
                });
                opt.AddPolicy(AuthorizationPolicies.DoktorPolicy, policy =>
                {
                    policy.RequireAssertion(context =>
                        {
                            var roles = context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

                            var listOfRoles = roles?.Split(",").ToList();

                            return listOfRoles?.Contains("Doktor") ?? false;
                        }
                    );
                });
                opt.AddPolicy(AuthorizationPolicies.MedicinskiTehnicarPolicy, policy =>
                {
                    policy.RequireAssertion(context =>
                        {
                            var roles = context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

                            var listOfRoles = roles?.Split(",").ToList();

                            return listOfRoles?.Contains("MedicinskiTehnicar") ?? false;
                        }
                    );
                });
                opt.AddPolicy(AuthorizationPolicies.RadnikPrijemPolicy, policy =>
                {
                    policy.RequireAssertion(context =>
                        {
                            var roles = context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

                            var listOfRoles = roles?.Split(",").ToList();

                            return listOfRoles?.Contains("RadnikPrijem") ?? false;
                        }
                    );
                });
            });

            return services;
        }
    }
}