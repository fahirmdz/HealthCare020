namespace HealthCare020.Core.Models
{
    public class ZahtevZaPregledDtoEL:ZahtevZaPregledDto
    {
        public PacijentDtoEL Pacijent { get; set; }

        public DoktorDtoEL Doktor { get; set; }

        public UputnicaDtoEL Uputnica { get; set; }
    }
}