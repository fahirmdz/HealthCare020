using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LargeDevicesStyle : ResourceDictionary
    {
        public static LargeDevicesStyle SharedInstance { get; } = new LargeDevicesStyle();

        public LargeDevicesStyle()
        {
            InitializeComponent();
        }
    }
}