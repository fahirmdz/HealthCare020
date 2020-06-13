namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class PosetaDtoEL:PosetaDto
    {
        public PacijentNaLecenjuDtoEL PacijentNaLecenju { get; set; }
    }
}