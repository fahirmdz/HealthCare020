using System.Collections.ObjectModel;
using Healthcare020.Mobile.Models;

namespace Healthcare020.Mobile.ViewModels
{
    public class ZakazaniPreglediViewModel : BaseViewModel
    {
        public ZakazaniPreglediViewModel()
        {

        }

        #region Properties

        public ObservableCollection<CollectionViewItem> ZakazaniPregledi { get; set; } =
            DevelopmentTestEntities.GetCollectioItemsZakazaniPregledi();

        #endregion
    }
}