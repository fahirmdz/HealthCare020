using System.Threading.Tasks;
using Acr.UserDialogs;
using Healthcare020.Mobile.Interfaces;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Services
{
    public class NotificationService
    {
        private static NotificationService _instance = null;
        public static NotificationService Instance => _instance ?? (_instance = new NotificationService());

        private readonly IHud HudNotify;

        private NotificationService()
        {
            HudNotify = DependencyService.Get<IHud>();
        }

        public void Success(string message = "")
        {
            if (Device.RuntimePlatform == Device.UWP)
                UserDialogs.Instance.Toast(string.IsNullOrWhiteSpace(message) ? "Uspešno!" : message);
            else
                HudNotify.Success(message);
        }

        public void Error(string message = "")
        {
            if (Device.RuntimePlatform == Device.UWP)
                UserDialogs.Instance.Toast(string.IsNullOrWhiteSpace(message) ? "Uspešno!" : message);
            else
                HudNotify.Error(message);
        }

        public void Toast(string message = "")
        {
            if (Device.RuntimePlatform == Device.UWP)
                UserDialogs.Instance.Toast(string.IsNullOrWhiteSpace(message) ? "Uspešno!" : message);
            else
                HudNotify.Toast(message);
        }

        public async Task<PromptResult> Prompt(string message="")
        {
            return await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                OkText = "Potvrdi",
                Title = "Sigurni ste?",
                Text = message
            });
        }


    }
}