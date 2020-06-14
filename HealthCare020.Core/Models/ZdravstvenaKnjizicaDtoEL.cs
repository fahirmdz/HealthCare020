namespace HealthCare020.Core.Models
{
    public class ZdravstvenaKnjizicaDtoEL:ZdravstvenaKnjizicaDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }
        public string Doktor { get; set; }
    }
}