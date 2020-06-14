using System.ComponentModel;

namespace HealthCare020.Core.Enums
{
    public enum RoleType
    {
        [Description("Admin")]
        Administrator,
        [Description("Doktor")]
        Doktor,
        [Description("RadnikPrijem")]
        RadnikPrijem,
        [Description("MedicinskiTehnicar")]
        MedicinskiTehnicar
    }

    public static class EnumExtension
    {
        public static string ToDescriptionString(this RoleType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    } 
}