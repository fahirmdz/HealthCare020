using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}