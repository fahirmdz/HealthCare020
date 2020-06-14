namespace HealthCare020.Core.Models
{
    public class PregledDtoEL:PregledDto
    {
        public ZahtevZaPregledDtoEL ZahtevZaPregled { get; set; }

        public string Doktor { get; set; }

        public PacijentDtoEL Pacijent { get; set; }
    }
}