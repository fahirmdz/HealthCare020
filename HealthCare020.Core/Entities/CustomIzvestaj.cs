using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class CustomIzvestaj
    {
        public int Id { get; set; }

        [Range(25,50)]
        [Required]
        public double TelesnaTemperatura { get; set; }

        [Range(50,250)]
        [Required]
        public int KrvniPritisakGornji { get; set; }

        [Range(50,250)]
        [Required]
        public int KrvniPritisakDonji { get; set; }

        [Range(1,100)]
        public double GlukozaUKrvi { get; set; }

        [Required]
        public DateTime DatumVreme { get; set; }

        [ForeignKey(nameof(MedicinskiTehnicar))]
        public int MedicinskiTehnicarId { get; set; }
        public MedicinskiTehnicar MedicinskiTehnicar { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}