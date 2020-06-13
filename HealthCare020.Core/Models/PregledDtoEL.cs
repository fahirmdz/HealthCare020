namespace HealthCare020.Core.Models
{
    public class PregledDtoEL:PregledDto
    {
        public ZahtevZaPregledDtoEL ZahtevZaPregled { get; set; }

        public DoktorDtoEL Doktor { get; set; }

        public PacijentDtoEL Pacijent { get; set; }
    }
}