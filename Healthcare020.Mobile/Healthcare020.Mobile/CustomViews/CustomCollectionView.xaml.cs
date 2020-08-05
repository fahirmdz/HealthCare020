using System;
using HealthCare020.Core.Models;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.CustomViews
{
    /// <summary>
    /// Custom collection view
    /// </summary>
    [ContentProperty("BaseCollectionViewModel")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCollectionView : ContentView
    {
        public static BindableProperty BaseCollectionViewModelProperty =
            BindableProperty.Create(nameof(BaseCollectionViewModel), typeof(BaseCollectionViewModel), typeof(CustomCollectionView),
                null, propertyChanged: CollectionChanged, defaultBindingMode: BindingMode.TwoWay);

        public BaseCollectionViewModel BaseCollectionViewModel
        {
            get => (BaseCollectionViewModel)GetValue(BaseCollectionViewModelProperty);
            set => SetValue(BaseCollectionViewModelProperty, value);
        }

        private static void CollectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        public CustomCollectionView()
        {
            InitializeComponent();
            LayoutChanged += MainContentArea_LayoutChanged;

        }


        private void MainContentArea_LayoutChanged(object sender, EventArgs e)
        {
            BindingContext = BaseCollectionViewModel;
            MainCollectionView.BindingContext = BaseCollectionViewModel;
        }
    }
}