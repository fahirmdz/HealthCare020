namespace HealthCare020.Core.Models
{
    public class ZdravstvenaKnjizicaDtoEL:ZdravstvenaKnjizicaDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }
        public string Doktor { get; set; }

        public ZdravstvenaKnjizicaDtoEL()
        {
            
        }
        public ZdravstvenaKnjizicaDtoEL(ZdravstvenaKnjizicaDtoEL zdravstvenaKnjizica)
        {
            Doktor = zdravstvenaKnjizica.Doktor;
            Id = zdravstvenaKnjizica.Id;
            DoktorId = zdravstvenaKnjizica.DoktorId;
            LicniPodaci=new LicniPodaciDto(zdravstvenaKnjizica.LicniPodaci);
        }
    }
}