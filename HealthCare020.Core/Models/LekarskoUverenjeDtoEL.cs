namespace HealthCare020.Core.Models
{
    public class LekarskoUverenjeDtoEL:LekarskoUverenjeDto
    {
        public PregledDtoEL Pregled { get; set; }

        public ZdravstvenoStanjeDto ZdravstvenoStanje { get; set; }
    }
}