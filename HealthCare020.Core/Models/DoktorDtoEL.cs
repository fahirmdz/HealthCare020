namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class DoktorDtoEL : RadnikDtoEL
    {
        public int Id { get; set; }
        public TwoFieldsDto NaucnaOblast { get; set; }
    }
}