namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class DnevniIzvestajDtoEL: DnevniIzvestajDto
    {
        public string ZdravstvenoStanje { get; set; }
        public string Doktor { get; set; }
        public string Pacijent { get; set; }
    }
}