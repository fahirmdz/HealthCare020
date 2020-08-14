using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Models;

namespace Healthcare020.Mobile.ViewModels
{
    public class LekarskaUverenjaViewModel : BaseListViewModel
    {
        public LekarskaUverenjaViewModel()
        {
            APIRouteToCollection = Routes.LekarskoUverenjeRoute;
            var RowsCount = ResourceParameters.PageSize;
            ResourceParameters = new LekarskoUverenjeResourceParameters()
            {
                PageSize = RowsCount,
                EagerLoaded = true
            };
        }

        protected override ObservableCollection<CollectionViewItem> CollectionViewItemConvertor(ObservableCollection<object> collection)
        {
            var collectionToReturn = new ObservableCollection<CollectionViewItem>();
            foreach (var item in collection.GetAs<LekarskoUverenjeDtoEL>())
            {
                collectionToReturn.Add(new CollectionViewItem
                {
                    Id = item.Id,
                    DateTime = item.Pregled?.DatumPregleda??new DateTime(),
                    PrimaryTextTitle = "Zdravstveno stanje: ",
                    PrimaryTextContent = item.ZdravstvenoStanje?.Opis??"N/A"
                });
            }

            return collectionToReturn;
        }

        protected override async Task Search()
        {
            if (string.Equals(SearchString, (ResourceParameters as LekarskoUverenjeResourceParameters)?.OpisStanja,
                StringComparison.InvariantCultureIgnoreCase))
                return;

            ((LekarskoUverenjeResourceParameters) ResourceParameters).OpisStanja = SearchString;

            await LoadData();
        }
    }
}