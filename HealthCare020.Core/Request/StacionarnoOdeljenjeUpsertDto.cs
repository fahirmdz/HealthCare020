using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class StacionarnoOdeljenjeUpsertDto
    {
        private string _naziv;
        [RequiredWithMessage()]
        [StringLengthWithMessage(4,40)]
        public string Naziv { get=>_naziv; set=>_naziv=value.RemoveWhitespaces(); }
    }
}