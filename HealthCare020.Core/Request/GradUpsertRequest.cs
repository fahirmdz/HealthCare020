using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class GradUpsertRequest
    {
        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Naziv mora sadrzati izmedju 2 i 20 karaktera")]
        public string Naziv { get; set; }

        public int DrzavaId { get; set; }
    }
}