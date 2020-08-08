using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class ZdravstvenoStanjeUpsertDto
    {
        [RequiredWithMessage]
        [StringLengthWithMessage(3,20)]
        [DataType(DataType.Text)]
        public string Opis { get; set; }
    }
}