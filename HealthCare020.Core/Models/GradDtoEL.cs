namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class GradDtoEL: GradDto
    {
        public DrzavaDto Drzava { get; set; }
    }
}