using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class ZdravstvenoStanjeUpsertRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Opis { get; set; }
    }
}