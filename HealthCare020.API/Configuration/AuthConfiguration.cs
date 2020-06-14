﻿using HealthCare020.API.Constants;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
                    policy.RequireAssertion(context=>authorizationHandler(context,AuthorizationPolicies.AdminPolicy).Invoke(context));

                });
                opt.AddPolicy(AuthorizationPolicies.DoktorPolicy, policy =>
                {
                    policy.RequireAssertion(context=>authorizationHandler(context,AuthorizationPolicies.DoktorPolicy).Invoke(context));

                });
                opt.AddPolicy(AuthorizationPolicies.MedicinskiTehnicarPolicy, policy =>
                {
                    policy.RequireAssertion(context=>authorizationHandler(context,AuthorizationPolicies.MedicinskiTehnicarPolicy).Invoke(context));
                });
                opt.AddPolicy(AuthorizationPolicies.RadnikPrijemPolicy, policy =>
                {
                    policy.RequireAssertion(context=>authorizationHandler(context,AuthorizationPolicies.RadnikPrijemPolicy).Invoke(context));
                });
            });

            Func<AuthorizationHandlerContext,bool> authorizationHandler(AuthorizationHandlerContext context, string policy)
            {
                var roles = context.User.Claims.FirstOrDefault(x => x.Type == "roles")?.Value;

                var listOfRoles = roles?.Split(",").Select(x=>x.Trim()).ToList();

                var isInRole = listOfRoles?.Any(x => x.Equals(policy, StringComparison.CurrentCultureIgnoreCase)) ??
                               false;

                return handlerContext => isInRole;
            }
            return services;
        }
    }
}