using System.ComponentModel;

namespace HealthCare020.Core.Enums
{
    public enum RoleType
    {
        [Description("Admin")]
        Administrator=1, //Numbering based on unique identifier from db
        [Description("Doktor")]
        Doktor,
        [Description("MedicinskiTehnicar")]
        MedicinskiTehnicar,
        [Description("RadnikPrijem")]
        RadnikPrijem,
        [Description("Pacijent")]
        Pacijent
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

        public static int ToInt(this RoleType val) => (int) val;
    } 
}