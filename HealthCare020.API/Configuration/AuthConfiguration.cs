using HealthCare020.API.Constants;
using HealthCare020.Core.Enums;
using IdentityModel.Client;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;
using System.Linq;

namespace HealthCare020.API.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IWebHostEnvironment env, IConfiguration Configuration)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication(options =>
               {
                   //options.Authority = ;
                   options.Authority = env.IsDevelopment() ? "https://localhost:5007/" : "http://healthcare020-oauth";
                   options.RequireHttpsMetadata = false;
                   options.IntrospectionDiscoveryPolicy = new DiscoveryPolicy
                   {
                       ValidateIssuerName = false
                   };
               });

            //****************Dev environment purposes only****************
            IdentityModelEventSource.ShowPII = true;

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(AuthorizationPolicies.AdministratorPolicy, policy =>
                {
                    policy.RequireAssertion(context => authorizationHandler(context, AuthorizationPolicies.AdministratorPolicy).Invoke(context));
                });
                opt.AddPolicy(AuthorizationPolicies.DoktorPolicy, policy =>
                {
                    policy.RequireAssertion(context => authorizationHandler(context, AuthorizationPolicies.DoktorPolicy).Invoke(context));
                });
                opt.AddPolicy(AuthorizationPolicies.MedicinskiTehnicarPolicy, policy =>
                {
                    policy.RequireAssertion(context => authorizationHandler(context, AuthorizationPolicies.MedicinskiTehnicarPolicy).Invoke(context));
                });
                opt.AddPolicy(AuthorizationPolicies.RadnikPrijemPolicy, policy =>
                {
                    policy.RequireAssertion(context => authorizationHandler(context, AuthorizationPolicies.RadnikPrijemPolicy).Invoke(context));
                });
                opt.AddPolicy(AuthorizationPolicies.PacijentPolicy, policy =>
                {
                    policy.RequireAssertion(context => authorizationHandler(context, AuthorizationPolicies.PacijentPolicy).Invoke(context));
                });
            });

            Func<AuthorizationHandlerContext, bool> authorizationHandler(AuthorizationHandlerContext context, string policy)
            {
                var roles = GetRoles(context);
                if (string.IsNullOrWhiteSpace(roles))
                    return handlerContext => false;

                var listOfRoles = roles.Split(",").Select(x => x.Trim()).ToList();
                if (!listOfRoles.Any())
                    return handlerContext => false;

                var roleOnTop = listOfRoles[0];

                //If Administrator logged in
                if (string.Equals(roleOnTop, RoleType.Administrator.ToDescriptionString(),
                    StringComparison.CurrentCultureIgnoreCase))
                    return handlerContext => true;

                //If RadnikPrijem required (SAMO RadnikPrijem i MedicinskiTehnicar mogu pristupiti podacima za koje je potreban RadnikPrijem policy)
                if (string.Equals(roleOnTop, RoleType.RadnikPrijem.ToDescriptionString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!string.Equals(policy, RoleType.RadnikPrijem.ToDescriptionString(),
                        StringComparison.CurrentCultureIgnoreCase) && !string.Equals(policy, RoleType.MedicinskiTehnicar.ToDescriptionString()))
                        return handlerContext => false;

                    return handlerContext => true;
                }

                var isInRole = listOfRoles.Any(x => x.Equals(policy, StringComparison.CurrentCultureIgnoreCase));

                return handlerContext => isInRole;
            }

            string GetRoles(AuthorizationHandlerContext context) => context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

            return services;
        }
    }
}