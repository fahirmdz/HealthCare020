using System.Linq;

namespace HealthCare020.Core.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveWhitespaces(this string input)
        {
            return new string(input.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}