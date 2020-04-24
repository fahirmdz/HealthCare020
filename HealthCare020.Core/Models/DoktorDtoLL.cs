namespace HealthCare020.Core.Models
{
    //LL -> Lazy Loaded
    public class DoktorDtoLL : RadnikDtoLL
    {
        public int Id { get; set; }
        public int NaucnaOblastId { get; set; }
    }
}