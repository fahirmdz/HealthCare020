using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LargeDevicesStyle
    {
        public static LargeDevicesStyle SharedInstance { get; } = new LargeDevicesStyle();

        public LargeDevicesStyle()
        {
            InitializeComponent();
        }
    }
}