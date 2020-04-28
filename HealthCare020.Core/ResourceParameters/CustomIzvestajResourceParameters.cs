namespace HealthCare020.Core.ResourceParameters
{
    public class CustomIzvestajResourceParameters:BaseResourceParameters
    {
        public bool EagerLoaded { get; set; } = false;

        public int? PacijentId { get; set; }
        public string PacijentIme { get; set; }
        public string PacijentPrezime { get; set; }
        public int? MedicinskiTehnicarId { get; set; }
        public string MedicinskiTehnicarIme { get; set; }
        public string MedicinskiTehnicarPrezime { get; set; }
        public string Datum { get; set; }
    }
}