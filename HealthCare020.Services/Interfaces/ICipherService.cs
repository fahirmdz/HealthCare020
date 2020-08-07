namespace HealthCare020.Services.Interfaces
{
    public interface ICipherService
    {
        string Encrypt(string input);

        string Decrypt(string cipherText);
    }
}