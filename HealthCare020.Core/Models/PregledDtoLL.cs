namespace HealthCare020.Core.Models
{
    public class PregledDtoLL : PregledDto
    {
        public int ZahtevZaPregledId { get; set; }

        public int DoktorId { get; set; }

        public int PacijentId { get; set; }
    }
}