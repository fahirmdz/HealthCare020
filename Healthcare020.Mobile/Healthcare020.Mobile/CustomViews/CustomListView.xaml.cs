using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.CustomViews
{
    /// <summary>
    /// Custom collection view
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomListView : ContentView
    {
        public ListView MainListView { get;}
        public CustomListView()
        {
            InitializeComponent();
            MainListView = MainCollectionView;
        }
    }
}