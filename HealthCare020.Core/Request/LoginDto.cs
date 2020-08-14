using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class LoginDto
    {
        [RequiredWithMessage]
        public string Username { get; set; }
        [RequiredWithMessage]
        public string Password { get; set; }
    }
}