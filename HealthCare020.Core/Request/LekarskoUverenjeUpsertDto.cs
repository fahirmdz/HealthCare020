using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class LekarskoUverenjeUpsertDto
    {
        [RequiredWithMessage()]
        public int PregledId { get; set; }

        [RequiredWithMessage]
        public int ZdravstvenoStanjeId { get; set; }

        [StringLengthWithMessage(5,255)]
        [RequiredWithMessage]
        public string OpisStanja { get; set; }
    }
}