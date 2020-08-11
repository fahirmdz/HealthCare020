using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Views;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.Models;
using HealthCare020.Core.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Services
{
    public enum AuthType
    {
        Credentials,
        FaceID
    }

    public sealed class Auth
    {
        public static SecureString AccessToken { get; private set; }

        #region Properties

        /// <summary>
        /// Current logged in user
        /// </summary>
        public static KorisnickiNalogDtoLL KorisnickiNalog
        {
            get; private set;
        }

        public static PacijentDtoEL Pacijent { get; set; }

        /// <summary>
        /// Role of current logged in user
        /// </summary>
        public static RoleType Role { get; private set; }

        #endregion Properties

        /// <summary>
        /// Authenticate user with username and password and get access token (store it in Auth.AccessToken)
        /// </summary>
        /// <returns>Returns boolean that indicates operation was succeeded or not</returns>
        public static async Task<bool> AuthenticateWithPassword(string username, string password, bool RememberMe = false)
        {
            try
            {
                if (RememberMe)
                {
                    await SecureStorage.SetAsync("Username", username);
                    await SecureStorage.SetAsync("Password", password);
                    await SecureStorage.SetAsync(PreferencesKeys.HasSavedLoginCredentials, true.ToString());
                }

                var responseToken =
                    await GetTokenAndSetAccessTokenAsync(GetTokenEndpointCredentialsRequestBodyContent(username, password));

                return await SetCurrentKorisnickiNalog();
            }
            catch (Exception ex)
            {
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return false;
            }
        }

        /// <summary>
        /// Authenticate user with Face ID
        /// </summary>
        /// <returns>Returns boolean that indicates operation was succeeded or not</returns>
        public static async Task<bool> AuthenticateWithFaceID(byte[] image, bool RememberMe = false)
        {
            try
            {
                var responseToken = await GetTokenAndSetAccessTokenAsync(GetTokenEndpointFaceRecognitionRequestBodyContent(image), AuthType.FaceID);

                return await SetCurrentKorisnickiNalog();
            }
            catch (Exception ex)
            {
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
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

        public static async Task Logout()
        {
            AccessToken = null;
            SecureStorage.Remove("Username");
            SecureStorage.Remove("Password");

            await SecureStorage.SetAsync(PreferencesKeys.HasSavedLoginCredentials, false.ToString());

            Application.Current.MainPage = new LoginPage();
        }

        public static bool IsAuthenticated() => AccessToken != null;

        //==================Helpers methods============================
        private static HttpContent GetTokenEndpointCredentialsRequestBodyContent(string username, string password)
        {
            var formDataAsQueryString = HttpUtility.ParseQueryString(string.Empty);
            formDataAsQueryString.Add("client_id", AppResources.IdpClientId);
            formDataAsQueryString.Add("client_secret", AppResources.IdpClientSecret);
            formDataAsQueryString.Add("grant_type", "password");
            formDataAsQueryString.Add("username", username);
            formDataAsQueryString.Add("password", password);
            formDataAsQueryString.Add("scope", "openid offline_access");

            return new StringContent(formDataAsQueryString.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        private static HttpContent GetTokenEndpointFaceRecognitionRequestBodyContent(byte[] image)
        {
            if (image == null || !image.Any())
                return null;

            var formDataDictionary = new Dictionary<string, string>
            {
                {"ClientId", AppResources.IdpClientId },
                {"ClientSecret", AppResources.IdpClientSecret },
                {"GrantType", "password" },
                {"Image", Convert.ToBase64String(image) },
                {"Scope", "openid offline_access face-recognition" }
            };
            var content = new FormUrlEncodedContent(formDataDictionary);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return content;
        }

        private static async Task<TokenResponse> GetTokenAndSetAccessTokenAsync(HttpContent content, AuthType authType = AuthType.Credentials)
        {
            if (content == null)
                return null;

            string uri = authType == AuthType.Credentials ? AppResources.IdpTokenEndpoint : AppResources.IdpTokenEndpointFaceId;

            HttpClientHandler clientHandler = new HttpClientHandler();

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                    clientHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                    };

                using (var client = new HttpClient(clientHandler))
                {
                    response = await client.PostAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseJson);
                    if (tokenResponse != null && !string.IsNullOrWhiteSpace(tokenResponse.AccessToken))
                    {
                        AccessToken = tokenResponse.AccessToken.ConvertToSecureString();
                        return tokenResponse;
                    }
                }

                var error = await response.Content.ReadAsStringAsync();
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return null;
            }
            catch (Exception ex)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return null;
            }
        }

        private static async Task<bool> SetCurrentKorisnickiNalog()
        {
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

        //==================/Helpers methods============================
    }
}