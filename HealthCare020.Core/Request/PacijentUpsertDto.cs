using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PacijentUpsertDto
    {
        [Required(ErrorMessage = "Morate unijeti ID uputa za lecenje")]
        public int UputZaLecenjeId { get; set; }
    }
}