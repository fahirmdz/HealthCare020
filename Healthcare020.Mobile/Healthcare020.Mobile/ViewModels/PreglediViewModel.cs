using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Models;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Healthcare020.Mobile.ViewModels
{
    public class PreglediViewModel : BaseListViewModel
    {
        public PreglediViewModel()
        {
            APIRouteToCollection = Routes.PreglediRoute;
            var RowsCount = ResourceParameters.PageSize;
            ResourceParameters = new PregledResourceParameters
            {
                PageSize = RowsCount,
                OnlyZakazani = false,
                EagerLoaded = true
            };
        }

        protected override ObservableCollection<CollectionViewItem> CollectionViewItemConvertor(ObservableCollection<object> collection)
        {
            var collectionToReturn = new ObservableCollection<CollectionViewItem>();
            foreach (var item in collection.GetAs<PregledDtoEL>())
            {
                collectionToReturn.Add(new CollectionViewItem
                {
                    Id = item.Id,
                    DateTime = item.DatumPregleda,
                    PrimaryTextTitle = "Doktor: ",
                    PrimaryTextContent = item.Doktor,
                    ItemFlag = item.IsOdradjen
                });
            }

            return collectionToReturn;
        }

        protected override async Task Search()
        {
            if (string.Equals(SearchString, (ResourceParameters as PregledResourceParameters)?.DoktorIme,
                StringComparison.InvariantCultureIgnoreCase))
                return;

            ((PregledResourceParameters) ResourceParameters).DoktorIme = SearchString;
            ((PregledResourceParameters) ResourceParameters).DoktorPrezime = SearchString;

            await LoadData();
        }
    }
}