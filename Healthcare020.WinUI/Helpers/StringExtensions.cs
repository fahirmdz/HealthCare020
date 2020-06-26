using System.Text.RegularExpressions;

namespace Healthcare020.WinUI.Helpers
{
    public static class StringExtensions
    {
        public static bool ValidatePhoneNumber(this string phone, bool IsRequired = false)
        {
            if (string.IsNullOrWhiteSpace(phone) && IsRequired)
                return true;

            if (string.IsNullOrWhiteSpace(phone) && IsRequired)
                return false;

            var cleaned = phone.RemoveNonNumeric();
            if (IsRequired && string.IsNullOrWhiteSpace(cleaned))
                return false;

            if (cleaned.Length < 12 || cleaned.Length>8)
                return true;

            return false;
        }

        public static string RemoveNonNumeric(this string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }
    }
}