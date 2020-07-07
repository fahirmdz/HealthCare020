using Flurl.Http;
using Healthcare020.Mobile.Resources;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        /// <summary>
        /// Authenticate user with username and password and get access token (store it in Auth.AccessToken)
        /// </summary>
        /// <returns>Returns boolean that indicates operation was succeeded or no</returns>
        public static async Task<bool> AuthenticateWithPassword(string username, string password, bool RememberMe = false)
        {
            try
            {
                if (RememberMe)
                {
                    await SecureStorage.SetAsync("Username", username);
                    await SecureStorage.SetAsync("Password", password);
                }
                //System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                //    (sender, cert, chain, sslPolicyErrors) =>
                //    {
                //        if (cert != null) System.Diagnostics.Debug.WriteLine(cert);
                //        return true;
                //    };

#if DEBUG
                HttpClientHandler clientHandler;

                if (Device.RuntimePlatform == Device.Android)
                    clientHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    };
                else
                    clientHandler = new HttpClientHandler();
#endif

                using (var client = new HttpClient(clientHandler))
                {
                    var accept = "application/json";
                    client.DefaultRequestHeaders.Add("Accept", accept);
                    var postBody = @"client_id=" + AppResources.IdpClientId
                                                 + "&client_secret=" + AppResources.IdpClientSecret
                                                 + "&grant_type=password&username="
                                                 + username + "&password=" + password
                                                 + "&scope=openid offline_access";

                    var response = client.PostAsync(Device.RuntimePlatform == Device.Android ? AppResources.IdpTokenEndpointAndroid : AppResources.IdpTokenEndpoint,
                        new StringContent(postBody, Encoding.UTF8, "application/x-www-form-urlencoded")).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseJson);
                        if (tokenResponse != null && !string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
                            AccessToken = tokenResponse.AccessToken.ConvertToSecureString();
                        else
                            return false;
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        return false;
                    }
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

        /// <summary>
        /// Get saved login credentials from previous login
        /// </summary>
        /// <returns>Boolean value indicates successful or unsuccessful login</returns>
        public static async Task<bool> AuthenticateWithSavedCredentials()
        {
            try
            {
                var username = await SecureStorage.GetAsync("Username");
                var password = await SecureStorage.GetAsync("Password");

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    return false;

                return await AuthenticateWithPassword(username, password);
            }
            catch
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