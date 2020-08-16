namespace HealthCare020.Core.Security
{
    public interface ISecurityService
    {
        string GenerateHash(string salt, string password);
        string GenerateSalt();
    }
}