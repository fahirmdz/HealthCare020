namespace HealthCare020.Core.ResourceParameters
{
    public class DoktorResourceParameters:BaseResourceParameters
    {
        public string NaucnaOblast { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public int? KorisnickiNalogId { get; set; }
        public bool EagerLoaded { get; set; } = false;
    }
}