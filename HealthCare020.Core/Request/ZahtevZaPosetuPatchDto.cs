using System;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class ZahtevZaPosetuPatchDto
    {
        public int PacijentNaLecenjuId { get; set; }

        private string _brojTelefona;
        [Phone]
        public string BrojTelefonaPosetioca { get=>_brojTelefona; set=>_brojTelefona=value.RemoveWhitespaces(); }

        public DateTime? ZakazanoDatumVreme { get; set; }

        public bool IsObradjen { get; set; } = false;
    }
}