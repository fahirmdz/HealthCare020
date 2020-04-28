namespace HealthCare020.Core.Models
{
    //LL -> Lazy Loaded
    public class DoktorDtoLL:DoktorDto
    {
        public int NaucnaOblastId { get; set; }
        public int RadnikId { get; set; }
    }
}