namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class PacijentDtoEL : PacijentDto
    {
        public ZdravstvenaKnjizicaDtoEL ZdravstvenaKnjizica { get; set; }
    }
}