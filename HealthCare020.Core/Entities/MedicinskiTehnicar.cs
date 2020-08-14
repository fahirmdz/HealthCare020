using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class MedicinskiTehnicar
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Radnik))]
        public int RadnikId { get; set; }

        public Radnik Radnik { get; set; }
    }
}