using HealthCare020.Core.Resources;

namespace HealthCare020.Core.Extensions
{
    public static class LocalizationExtensions
    {
        public static string LocalizeStringFromResource(this string name) => SharedResources.ResourceManager.GetString(name);
    }
}