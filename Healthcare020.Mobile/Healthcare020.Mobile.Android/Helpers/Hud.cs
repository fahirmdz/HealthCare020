using AndroidHUD;
using Healthcare020.Mobile.Droid.Helpers;
using Healthcare020.Mobile.Interfaces;
using Plugin.CurrentActivity;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Hud))]

namespace Healthcare020.Mobile.Droid.Helpers
{
    public class Hud : IHud
    {
        public Hud()
        {
        }

        public void Show()
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity);
        }

        public void Show(string message)
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, message);
        }

        public void Dismiss()
        {
            AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
        }

        public void Success(string message = "")
        {
            AndHUD.Shared.ShowSuccessWithStatus(CrossCurrentActivity.Current.Activity, string.IsNullOrWhiteSpace(message) ? "Uspešno!" : message, MaskType.Black, TimeSpan.FromSeconds(1));
        }

        public void Progress()
        {
            ShowProgress(progress => AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, "Loading... " + progress + "%", progress, MaskType.Black));
        }

        public void Toast(string message)
        {
            AndHUD.Shared.ShowToast(CrossCurrentActivity.Current.Activity, message, MaskType.Black, TimeSpan.FromSeconds(1.5), true);

        }

        public void Error(string message)
        {
            AndHUD.Shared.ShowErrorWithStatus(CrossCurrentActivity.Current.Activity, string.IsNullOrWhiteSpace(message)?"Greška!":message, MaskType.Black, TimeSpan.FromSeconds(2));
        }


        void ShowProgress(Action<int> action)
        {
            Task.Run(() => {
                int progress = 0;

                while (progress <= 100)
                {
                    action(progress);

                    new ManualResetEvent(false).WaitOne(500);
                    progress += 10;
                }

                AndHUD.Shared.Dismiss(CrossCurrentActivity.Current.Activity);
            });
        }


        //switch (demo)
        //    {
        //        case "Status Indicator Only":
        //            AndHUD.Shared.Show(this, null, -1, MaskType.Black, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Status Indicator and Text":
        //            AndHUD.Shared.Show(this, "Loading...", -1, MaskType.Clear, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Non-Modal Indicator and Text":
        //            AndHUD.Shared.Show(this, "Loading...", -1, MaskType.None, TimeSpan.FromSeconds(5));
        //            break;
        //        case "Progress Only":
        //            ShowProgressDemo(progress => AndHUD.Shared.Show(this, null, progress, MaskType.Clear));
        //            break;
        //        case "Progress and Text":
        //
        //            break;
        //        case "Success Image Only":
        //            AndHUD.Shared.ShowSuccessWithStatus(this, null, MaskType.Black, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Success Image and Text":
        //            AndHUD.Shared.ShowSuccessWithStatus(this, "It Worked!", MaskType.Clear, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Error Image Only":
        //            AndHUD.Shared.ShowErrorWithStatus(this, null, MaskType.Clear, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Error Image and Text":
        //            AndHUD.Shared.ShowErrorWithStatus(this, "It no worked :(", MaskType.Black, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Toast":
        //            AndHUD.Shared.ShowToast(this, "This is a toast... Cheers!", MaskType.Black, TimeSpan.FromSeconds(3), true);
        //            break;
        //        case "Toast Non-Centered":
        //            AndHUD.Shared.ShowToast(this, "This is a non-centered Toast...", MaskType.Clear, TimeSpan.FromSeconds(3), false);
        //            break;
        //        case "Custom Image":
        //            AndHUD.Shared.ShowImage(this, Resource.Drawable.ic_questionstatus, "Custom Image...", MaskType.Black, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Click Callback":
        //            AndHUD.Shared.ShowToast(this, "Click this toast to close it!", MaskType.Clear, null, true, () => AndHUD.Shared.Dismiss(this));
        //            break;
        //        case "Cancellable Callback":
        //            AndHUD.Shared.ShowToast(this, "Click back button to cancel/close it!", MaskType.None, null, true, null, () => AndHUD.Shared.Dismiss(this));
        //            break;
        //        case "Long Message":
        //            AndHUD.Shared.Show(this, "This is a longer message to display!", -1, MaskType.Black, TimeSpan.FromSeconds(3));
        //            break;
        //        case "Really Long Message":
        //            AndHUD.Shared.Show(this, "This is a really really long message to display as a status indicator, so you should shorten it!", -1, MaskType.Black, TimeSpan.FromSeconds(3));
        //            break;
        //    }
    }
}