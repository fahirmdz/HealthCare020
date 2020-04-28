using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class TokenPoseta
    {
        public int Id { get; set; }

        [StringLength(maximumLength:10,MinimumLength = 5)]
        public string Value { get; set; }

        [Range(0,6,ErrorMessage = "Broj preostalih poseta moze biti u rasponu od 0 do 6")]
        public int BrojPreostalihPoseta { get; set; } = 6;

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        public virtual ICollection<Poseta> Posete { get; set; }
    }
}