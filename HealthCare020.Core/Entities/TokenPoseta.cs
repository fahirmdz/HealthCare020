using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Entities
{
    public class TokenPoseta
    {
        public int Id { get; set; }

        [StringLength(maximumLength:10,MinimumLength = 5)]
        public string Value { get; set; }
    }
}