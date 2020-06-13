namespace HealthCare020.Core.Models
{
    public class ZdravstvenaKnjizicaDtoEL:ZdravstvenaKnjizicaDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }

        public DoktorDtoEL Doktor { get; set; }
    }
}