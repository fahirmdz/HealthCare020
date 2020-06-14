namespace HealthCare020.Core.Models
{
    public class UputnicaDtoEL : UputnicaDto
    {
        public PacijentDtoEL Pacijent { get; set; }

        public string UputioDoktor { get; set; }

        public string UpucenKodDoktora { get; set; }
    }
}