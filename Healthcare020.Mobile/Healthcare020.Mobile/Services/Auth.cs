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

        /// <summary>
        /// Current logged in Pacijent
        /// </summary>
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
                if (!await GetTokenAndSetAccessTokenAsync(GetTokenEndpointCredentialsRequestBodyContent(username, password)))
                    return false;
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
                if (!await GetTokenAndSetAccessTokenAsync(GetTokenEndpointFaceRecognitionRequestBodyContent(image),
                    AuthType.FaceID))
                    return false;
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

        /// <summary>
        /// User is logged in or not
        /// </summary>
        /// <param name="setLoginPage">Set Login page as the main page, if the user is not logged in. Default is TRUE</param>
        /// <returns>TRUE is the user is logged in, otherwise FALSE</returns>
        public static bool IsAuthenticated(bool setLoginPage = true)
        {
            var authenticated = AccessToken != null;

            if (setLoginPage && !authenticated)
                Application.Current.MainPage = new LoginPage();
            return authenticated;
        }

        //==================Helpers methods============================
        private static HttpContent GetTokenEndpointCredentialsRequestBodyContent(string username, string password)
        {
            try
            {
                var formDataAsQueryString = HttpUtility.ParseQueryString(string.Empty);
                formDataAsQueryString.Add("client_id", AppResources.IdpClientId);
                formDataAsQueryString.Add("client_secret", AppResources.IdpClientSecret);
                formDataAsQueryString.Add("grant_type", "password");
                formDataAsQueryString.Add("username", username);
                formDataAsQueryString.Add("password", password);
                formDataAsQueryString.Add("scope", "openid offline_access");

                return new StringContent(formDataAsQueryString.ToString(), Encoding.UTF8,
                    "application/x-www-form-urlencoded");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static HttpContent GetTokenEndpointFaceRecognitionRequestBodyContent(byte[] image)
        {
            try
            {
                if (image == null || !image.Any())
                    return null;

                var requestBody = new
                {
                    ClientId = AppResources.IdpClientId,
                    ClientSecret = AppResources.IdpClientSecret,
                    GrantType = "password",
                    Image = Convert.ToBase64String(image),
                    Scope = "openid offline_access face-recognition"
                };
                var content = new StringContent(JsonConvert.SerializeObject(requestBody));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return content;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static async Task<bool> GetTokenAndSetAccessTokenAsync(HttpContent content,
            AuthType authType = AuthType.Credentials)
        {
            if (content == null)
                return false;

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
                        return true;
                    }
                }

                var str=await response.Content.ReadAsStringAsync();
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static async Task<bool> SetCurrentKorisnickiNalog()
        {
            try
            {
                var apiSerivce = new APIService(Routes.PacijentiRoute);
                var pacijentGetResult = await apiSerivce.GetById<PacijentDtoEL>(0, eagerLoaded: true); // Id = 0 to return current logged in Pacijent

                if (!pacijentGetResult.Succeeded)
                {
                    AccessToken = null;
                    return false;
                }

                Pacijent = pacijentGetResult.Data;
                KorisnickiNalog = Pacijent.KorisnickiNalog;
                var topRole = KorisnickiNalog.Roles?.Min(x => x);
                Role = topRole.HasValue ? (RoleType)topRole : RoleType.Pacijent;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //==================/Helpers methods============================
    }
}