using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ITelegramBot
    {
        public Task SendMessageAsync(string message);
    }
}