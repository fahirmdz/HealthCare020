namespace HealthCare020.Core.Models
{
    public class PregledDtoEL:PregledDto
    {
        public string Doktor { get; set; }

        public PacijentDtoEL Pacijent { get; set; }
    }
}