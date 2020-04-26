namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class DoktorDtoEL:DoktorDto
    {
        public TwoFieldsDto NaucnaOblast { get; set; }
        public RadnikDtoEL Radnik { get; set; }
    }
}