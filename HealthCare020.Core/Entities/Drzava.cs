using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Entities
{
    public class Drzava
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Naziv { get; set; }

        public string PozivniBroj { get; set; }

        public virtual ICollection<Grad> Gradovi { get; set; }
    }
}