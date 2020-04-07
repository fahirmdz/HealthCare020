using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class ZdravstvenoStanjeUpsertRequest
    {
        [Required(ErrorMessage = "Opis je obavezno polje")]
        [StringLength(maximumLength: 20, MinimumLength = 3,ErrorMessage = "Opis mora sadrzati izmedju 3 i 20 karaktera")]
        [DataType(DataType.Text)]
        public string Opis { get; set; }
    }
}