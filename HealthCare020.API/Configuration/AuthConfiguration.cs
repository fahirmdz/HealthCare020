using HealthCare020.API.Constants;
using HealthCare020.Core.Enums;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HealthCare020.API.Configuration
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               .AddIdentityServerAuthentication(options =>
               {
                   options.Authority = env.IsDevelopment()?"https://localhost:5007/":"https://healthcare020-oauth.com:5005/";
                   options.RequireHttpsMetadata = false;
                   options.IntrospectionDiscoveryPolicy = new DiscoveryPolicy
                   {
                       ValidateIssuerName = false
                   };
               });

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

                var roleOnTop = roles.Split(",")[0];

                //If Administrator logged in
                if (string.Equals(roleOnTop, RoleType.Administrator.ToDescriptionString(),
                    StringComparison.CurrentCultureIgnoreCase))
                    return handlerContext => true;

                //If RadnikPrijem required (SAMO RadnikPrijem moze pristupiti podacima za koje je potreban RadnikPrijem policy)
                if (string.Equals(roleOnTop,RoleType.RadnikPrijem.ToDescriptionString(),StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!string.Equals(policy, RoleType.RadnikPrijem.ToDescriptionString(),
                        StringComparison.CurrentCultureIgnoreCase))
                        return handlerContext => false;

                    return handlerContext => true;
                }

                var listOfRoles = roles?.Split(",").Select(x => x.Trim()).ToList();

                var isInRole = listOfRoles?.Any(x => x.Equals(policy, StringComparison.CurrentCultureIgnoreCase)) ??
                               false;

                return handlerContext => isInRole;
            }

            string GetRoles(AuthorizationHandlerContext context) => context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

            return services;
        }

    }
}