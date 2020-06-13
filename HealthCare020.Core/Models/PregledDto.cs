using System;

namespace HealthCare020.Core.Models
{
    public abstract class PregledDto
    {
        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public bool IsOdradjen { get; set; }
    }
}