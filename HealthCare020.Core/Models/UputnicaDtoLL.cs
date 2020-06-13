namespace HealthCare020.Core.Models
{
    //LL -> Lazy Loaded
    public class UputnicaDtoLL:UputnicaDto
    {
        public int PacijentId { get; set; }

        public int UputioDoktorId { get; set; }

        public int UpucenKodDoktoraId { get; set; }
    }
}