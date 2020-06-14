namespace HealthCare020.Core.Models
{
    public class ZahtevZaPregledDtoEL:ZahtevZaPregledDto
    {
        public PacijentDtoEL Pacijent { get; set; }

        public string Doktor { get; set; }

        public UputnicaDtoEL Uputnica { get; set; }
    }
}