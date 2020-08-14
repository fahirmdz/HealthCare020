namespace HealthCare020.Core.Models
{
    public class ZahtevZaPregledDtoLL:ZahtevZaPregledDto
    {
        public int PacijentId { get; set; }

        public int DoktorId { get; set; }

        public int? UputnicaId { get; set; }
    }
}