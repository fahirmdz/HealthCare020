using Healthcare020.Mobile.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.CustomViews
{
    /// <summary>
    /// Custom collection view
    /// </summary>
    [ContentProperty("MainCollection")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCollectionView : ContentView
    {
        public static readonly BindableProperty MainCollectionProperty =
            BindableProperty.Create(nameof(MainCollection), typeof(ObservableCollection<CollectionViewItem>), typeof(CustomCollectionView),
                new ObservableCollection<CollectionViewItem>(), propertyChanged: CollectionChanged,defaultBindingMode: BindingMode.TwoWay);


        public ObservableCollection<CollectionViewItem> MainCollection
        {
            get => (ObservableCollection<CollectionViewItem>)GetValue(MainCollectionProperty);
            set => SetValue(MainCollectionProperty, value);
        }

        private static void CollectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        public CustomCollectionView()
        {
            InitializeComponent();
            MainCollectionView.BindingContext = this;
        }
    }
}