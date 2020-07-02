using Flurl.Http;
using Healthcare020.WinUI.Forms;
using Healthcare020.WinUI.Properties;
using Healthcare020.WinUI.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Enums;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Clients;

namespace Healthcare020.WinUI.Helpers
{
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

        public static DoktorDtoLL CurrentLoggedInDoktor { get; private set; }

        /// <summary>
        /// Role of current logged in user
        /// </summary>
        public static RoleType Role { get; private set; }

        public static IFlurlRequest GetAuthorizedApiRequest(string relativePath = "")
        {
            return (Properties.Settings.Default.ApiUrl + relativePath).WithHeader("Authorization", $"Bearer {new NetworkCredential(string.Empty, AccessToken).Password}");
        }

        /// <summary>
        /// Authenticate user with username and password and get access token (store it in Auth.AccessToken)
        /// </summary>
        /// <returns>Returns boolean that indicates operation was succeeded or no</returns>
        public static async Task<bool> AuthenticateWithPassword(string username, string password)
        {
            try
            {
                var client = new OAuth2Client(new Uri(Properties.Settings.Default.IdpTokenEndpoint), Properties.Settings.Default.IdpClientId,
                    Properties.Settings.Default.IdpClientSecret);
                var tokens = client.RequestAccessTokenUserName(username, password, string.Empty);
                AccessToken = new NetworkCredential(string.Empty, tokens.AccessToken).SecurePassword;

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

                if (Role == RoleType.Doktor)
                {
                    apiSerivce.ChangeRoute(Routes.DoktoriRoute);
                    var doktorResult = await apiSerivce.Get<DoktorDtoLL>(new DoktorResourceParameters
                    { EqualUsername = KorisnickiNalog.Username });
                    if (doktorResult.Succeeded && doktorResult.HasData)
                    {
                        CurrentLoggedInDoktor = doktorResult.Data.First();
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Logout()
        {
            AccessToken = null;
            using (var reg = Registry.CurrentUser.OpenSubKey(Properties.Settings.Default.RegistryKey, true))
            {
                if (reg != null)
                {
                    reg.SetValue(Resources.RegistryKeyValueUsername, string.Empty);
                    reg.SetValue(Resources.RegistryKeyValuePassword, string.Empty);
                    reg.Close();
                }
            }
            MainForm.Instance.SetLoginAsChildForm();
        }

        public static bool IsAuthenticated() => AccessToken != null;
    }
}