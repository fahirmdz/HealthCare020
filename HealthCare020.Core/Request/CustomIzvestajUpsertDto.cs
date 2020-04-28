using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class CustomIzvestajUpsertDto
    {
        [Range(25, 50)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public double TelesnaTemperatura { get; set; }

        [Range(50, 250)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public int KrvniPritisakGornji { get; set; }

        [Range(50, 250)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public int KrvniPritisakDonji { get; set; }

        [Range(1, 100)]
        public double GlukozaUKrvi { get; set; }

        public int PacijentId { get; set; }
    }
}