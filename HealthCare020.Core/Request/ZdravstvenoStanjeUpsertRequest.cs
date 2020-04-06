using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HealthCare020.Core.Request
{
    public class ZdravstvenoStanjeUpsertRequest
    {
        [StringLength(maximumLength: 20, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Opis { get; set; }
    }
}