using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmallDevicesStyle : ResourceDictionary
    {
        public static SmallDevicesStyle SharedInstance { get; } = new SmallDevicesStyle();

        public SmallDevicesStyle()
        {
            InitializeComponent();
        }
    }
}