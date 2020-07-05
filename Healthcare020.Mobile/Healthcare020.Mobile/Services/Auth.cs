using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Models;
using Healthcare020.Mobile.Resources;
using Newtonsoft.Json;

namespace Healthcare020.Mobile.Services
{
    internal class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIN { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }

    public sealed class Auth
    {
        public static SecureString AccessToken { get; private set; }

        /// <summary>
        /// Current logged in user
        /// </summary>
        public static KorisnickiNalogDtoLL KorisnickiNalog
        {
            get; private set;
        }

        /// <summary>
        /// Role of current logged in user
        /// </summary>
        public static RoleType Role { get; private set; }

        public static IFlurlRequest GetAuthorizedApiRequest(string relativePath = "")
        {
            return (AppResources.ApiUrl+ relativePath).WithHeader("Authorization", $"Bearer {new NetworkCredential(string.Empty, AccessToken).Password}");
        }

        /// <summary>
        /// Authenticate user with username and password and get access token (store it in Auth.AccessToken)
        /// </summary>
        /// <returns>Returns boolean that indicates operation was succeeded or no</returns>
        public static async Task<bool> AuthenticateWithPassword(string username, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var accept = "application/json";
                    client.DefaultRequestHeaders.Add("Accept", accept);
                    var postBody = @"client_id=" + AppResources.IdpClientId 
                                                    + "&client_secret=" + AppResources.IdpClientSecret 
                                                    + "&grant_type=password&username=" 
                                                    + username + "&password=" + password 
                                                    + "&scope= openid offline_access";

                    var response = client.PostAsync(AppResources.IdpTokenEndpoint,
                        new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseJson);
                        if (tokenResponse != null && !string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
                            AccessToken = new NetworkCredential(string.Empty, tokenResponse.AccessToken).SecurePassword;
                        else
                            return false;
                    }
                    else
                        return false;
                }

                var apiSerivce = new APIService(Routes.KorisniciRoute);

                var result = await apiSerivce.GetById<KorisnickiNalogDtoLL>(0);
                if (!result.Succeeded)
                {
                    AccessToken = null;
                    return false;
                }
                KorisnickiNalog = result.Data;

                var topRole = KorisnickiNalog.Roles?.Min(x => x);
                Role = topRole.HasValue ? (RoleType)topRole : RoleType.Pacijent;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Logout()
        {
            AccessToken = null;
        }

        public static bool IsAuthenticated() => AccessToken != null;
    }
}