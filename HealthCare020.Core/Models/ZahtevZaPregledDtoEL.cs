namespace HealthCare020.Core.Models
{
    public class ZahtevZaPregledDtoEL:ZahtevZaPregledDto
    {
        public PacijentDtoEL Pacijent { get; set; }

        public string Doktor { get; set; }

        public UputnicaDtoEL Uputnica { get; set; }

        public ZahtevZaPregledDtoEL()
        {
            
        }

        public ZahtevZaPregledDtoEL(ZahtevZaPregledDtoEL zahtevZaPregled)
        {
            Id = zahtevZaPregled.Id;
            Napomena = zahtevZaPregled.Napomena;
            DatumVreme = zahtevZaPregled.DatumVreme;
            Pacijent=new PacijentDtoEL(zahtevZaPregled.Pacijent);
            Doktor = zahtevZaPregled.Doktor;
            if (zahtevZaPregled.Uputnica != null)
                Uputnica = new UputnicaDtoEL(zahtevZaPregled.Uputnica);
            else
                Uputnica = null;
        }
    }
}