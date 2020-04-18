namespace HealthCare020.Core.ResourceParameters
{
    public class KorisnickiNalogResourceParameters:BaseResourceParameters
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public bool EagerLoaded  { get; set; }
    }
}