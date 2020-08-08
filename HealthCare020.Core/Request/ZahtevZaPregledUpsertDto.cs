using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class ZahtevZaPregledUpsertDto
    {
        [RequiredWithMessage]
        public int DoktorId { get; set; }

        public int? UputnicaId { get; set; }

        [StringLengthWithMessage(5, 255)]
        [RequiredWithMessage]
        public string Napomena { get; set; }
    }
}