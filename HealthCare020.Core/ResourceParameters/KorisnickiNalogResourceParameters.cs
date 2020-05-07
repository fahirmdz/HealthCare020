namespace HealthCare020.Core.ResourceParameters
{
    public class KorisnickiNalogResourceParameters:BaseResourceParameters
    {
        public string Username { get; set; }
        public bool LockedOut { get; set; }
        public bool EagerLoaded  { get; set; }
    }
}