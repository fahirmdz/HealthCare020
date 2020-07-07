using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare020.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacijentDasbhboardTabbedPage : TabbedPage
    {
        public PacijentDasbhboardTabbedPage()
        {
            InitializeComponent();

            var fontAwesomeRegular = Application.Current.Resources["FontAwesomeRegular"] as OnPlatform<string>;

            PreglediTab.IconImageSource = new FontImageSource
            {
                FontFamily = fontAwesomeRegular,
                Glyph = IconFont.Stethoscope,
                Color = Color.FromRgb(0, 130, 130),
                Size = 50
            };

            UverenjaTab.IconImageSource=new FontImageSource
            {
                FontFamily = fontAwesomeRegular,
                Glyph = IconFont.FileSignature,
                Color = Color.FromRgb(0,130,130),
                Size = 50
            };

            ZahteviTab.IconImageSource=new FontImageSource
            {
                FontFamily = fontAwesomeRegular,
                Glyph = IconFont.Question,
                Color = Color.FromRgb(0,130,130),
                Size = 50
            };
        }
    }
}