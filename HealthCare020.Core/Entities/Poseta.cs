using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Poseta
    {
        public int Id { get; set; }

        public DateTime DatumVreme { get; set; }

        [ForeignKey(nameof(TokenPoseta))]
        public int TokenPosetaId { get; set; }
        public TokenPoseta TokenPoseta { get; set; }
    }
}