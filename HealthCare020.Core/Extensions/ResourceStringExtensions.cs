namespace HealthCare020.Core.Extensions
{
    public static class ResourceStringExtensions
    {
        /// <summary>
        /// Replace one # character of resource string with name of entity/resource
        /// </summary>
        /// <returns></returns>
        public static string With(this string str, string name)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return str.Replace("#", name);
        }

        /// <summary>
        /// Replace two # character of resource string with 2 values
        /// </summary>
        public static string With(this string str, string first, string second)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            str = str.ReplaceFirstOccurrence("#", first);
            return str.ReplaceFirstOccurrence("#", second);
        }

        /// <summary>
        /// Replace three # character of resource string with 3 values
        /// </summary>
        public static string With(this string str, string first, string second, string third)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            str = str.ReplaceFirstOccurrence("#", first);
            str = str.ReplaceFirstOccurrence("#", second);
            return str.ReplaceFirstOccurrence("#", third);
        }
    }
}