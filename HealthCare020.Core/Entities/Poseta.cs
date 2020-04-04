using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Poseta
    {
        public int Id { get; set; }
        
        [StringLength(maximumLength:15,MinimumLength = 2)]
        public string PosetiocIme { get; set; }

        [StringLength(maximumLength:15,MinimumLength = 2)]
        public string PosetiocPrezime { get; set; }

        public DateTime DatumVreme { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}