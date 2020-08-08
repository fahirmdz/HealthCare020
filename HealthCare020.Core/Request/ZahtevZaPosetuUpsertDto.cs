using HealthCare020.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class ZahtevZaPosetuUpsertDto
    {
        [RequiredWithMessage()]
        public int PacijentNaLecenjuId { get; set; }

        private string _brojTelefona;
        [Phone]
        [RequiredWithMessage]
        public string BrojTelefonaPosetioca { get => _brojTelefona; set => _brojTelefona = value.RemoveWhitespaces(); }
    }
}