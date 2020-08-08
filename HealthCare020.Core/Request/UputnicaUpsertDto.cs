using System;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class UputnicaUpsertDto
    {
        [RequiredWithMessage()]
        public int PacijentId { get; set; }

        [RequiredWithMessage]
        public int UpucenKodDoktoraId { get; set; }

        [RequiredWithMessage]
        [StringLengthWithMessage(1,255)]
        public string Razlog { get; set; }

        [StringLengthWithMessage(1,255)]
        public string Napomena { get; set; }

        [RequiredWithMessage]
        [FutureDateTime]
        public DateTime DatumVreme { get; set; }
    }
}