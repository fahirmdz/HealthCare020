using System;
using System.Security.Cryptography;
using System.Text;

namespace Healthcare020.WinUI.Services
{
    public static class DataProtectionExtensions
    {
        public static string Protect(this string text, string optionalEntropy = null,
            DataProtectionScope scope = DataProtectionScope.CurrentUser)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            var clearBytes = Encoding.UTF8.GetBytes(text);
            var entropyBytes = string.IsNullOrWhiteSpace(optionalEntropy)
                ? null
                : Encoding.UTF8.GetBytes(optionalEntropy);
            var encryptedBytes = ProtectedData.Protect(clearBytes, entropyBytes, scope);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Unprotect(this string encryptedText, string optionalEntropy = null,
            DataProtectionScope scope = DataProtectionScope.CurrentUser)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                return string.Empty;

            var encryptedBytes = Convert.FromBase64String(encryptedText);
            var entropyBytes = string.IsNullOrWhiteSpace(optionalEntropy) ? null : Encoding.UTF8.GetBytes(optionalEntropy);
            var clearBytes = ProtectedData.Unprotect(encryptedBytes, entropyBytes, scope);
            return Encoding.UTF8.GetString(clearBytes);
        }
    }
}