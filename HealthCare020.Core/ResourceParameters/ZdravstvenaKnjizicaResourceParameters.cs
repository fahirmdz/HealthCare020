namespace HealthCare020.Core.ResourceParameters
{
    public class ZdravstvenaKnjizicaResourceParameters
    {
        public LicniPodaciResourceParameters LicniPodaci { get; set; }
        public int? DoktorId { get; set; }
        public string DoktorImePrezime { get; set; }
    }
}