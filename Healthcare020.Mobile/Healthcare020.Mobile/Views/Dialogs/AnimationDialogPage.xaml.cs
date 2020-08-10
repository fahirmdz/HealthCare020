using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimationDialogPage
    {
        public AnimationDialogPage(string animationPath)
        {
            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            HasKeyboardOffset = false;
            this.BackgroundColor = Color.FromRgba(0, 0, 0, 0.4);

            InitializeComponent();
            this.MainAnimation.Animation = animationPath;
        }
    }
}