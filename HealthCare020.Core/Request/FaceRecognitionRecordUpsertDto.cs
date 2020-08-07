using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class FaceRecognitionRecordUpsertDto
    {
        [Required]
        public int KorisnickiNalogId { get; set; }
        public DateTime DateTime { get; set; }
        public string Key { get; set; }
    }
}