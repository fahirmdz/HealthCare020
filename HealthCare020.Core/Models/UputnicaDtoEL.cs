namespace HealthCare020.Core.Models
{
    public class UputnicaDtoEL : UputnicaDto
    {
        public PacijentDtoEL Pacijent { get; set; }

        public string UputioDoktor { get; set; }

        public string UpucenKodDoktora { get; set; }

        public UputnicaDtoEL()
        {
        }

        public UputnicaDtoEL(UputnicaDtoEL uputnica)
        {
            Id = uputnica.Id;
            UputioDoktorId = uputnica.UputioDoktorId;
            UpucenKodDoktoraId = uputnica.UpucenKodDoktoraId;
            Razlog = uputnica.Razlog;
            Napomena = uputnica.Napomena;
            DatumVreme = uputnica.DatumVreme;
            Pacijent=new PacijentDtoEL(uputnica.Pacijent);
            UputioDoktor = uputnica.UputioDoktor;
            UpucenKodDoktora = uputnica.UpucenKodDoktora;
        }
    }
}