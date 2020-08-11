using HealthCare020.Core.Constants;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Healthcare020.OAuth.Configuration
{
    public static class InMemoryConfig
    {
        public static string FaceRecognitionScope = "face-recognition";
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(FaceRecognitionScope,new []{""})
        };

        public static IEnumerable<ApiResource> Apis = new List<ApiResource>
        {
            // local API
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = OAuthConstants.WebAPIClientId,
                    ClientSecrets = new [] { new Secret("devsecret_api".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId,FaceRecognitionScope,IdentityServerConstants.LocalApi.ScopeName },
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AbsoluteRefreshTokenLifetime = 2592000,
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = OAuthConstants.MobileClientId,
                    ClientSecrets = new [] { new Secret("devsecret_mobile".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId,FaceRecognitionScope,IdentityServerConstants.LocalApi.ScopeName },
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AbsoluteRefreshTokenLifetime = 2592000,
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = OAuthConstants.DesktopClientId,
                    ClientSecrets = new [] { new Secret("devsecret_desktop".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.LocalApi.ScopeName },
                    RefreshTokenUsage = TokenUsage.ReUse,
                    RefreshTokenExpiration = TokenExpiration.Sliding,
                    AbsoluteRefreshTokenLifetime = 2592000,
                    AllowOfflineAccess = true
                    }
            };

        public static List<TestUser> GetUsers() =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
                    Username = "Mick",
                    Password = "MickPassword",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Mick"),
                        new Claim("family_name", "Mining")
                    }
                },
                new TestUser
                {
                    SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
                    Username = "Jane",
                    Password = "JanePassword",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Jane"),
                        new Claim("family_name", "Downing")
                    }
                }
            };
    }
}