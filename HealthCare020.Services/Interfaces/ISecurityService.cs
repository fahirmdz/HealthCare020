namespace HealthCare020.Services.Interfaces
{
    public interface ISecurityService
    {
        public string GenerateHash(string salt, string password);
        public string GenerateSalt();
    }
}