using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PosetaUpsertDto
    {
        [Required(ErrorMessage = "Morate unijeti token za posetu",AllowEmptyStrings = false)]
        [MaxLength(6,ErrorMessage = "Token za posetu mora sadrzati 6 cifara")]
        [MinLength(6,ErrorMessage = "Token za posetu mora sadrzati 6 cifara")]
        public string TokenPoseta { get; set; }
    }
}