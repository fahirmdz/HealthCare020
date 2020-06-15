namespace HealthCare020.Core.Models
{
    //EL -> Eager Loaded
    public class ZahtevZaPosetuDtoEL:ZahtevZaPosetuDto
    {
        public PacijentNaLecenjuDtoEL PacijentNaLecenju { get; set; }
    }
}