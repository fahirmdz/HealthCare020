using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Healthcare020.Mobile.Helpers
{
    public static class ObservableExtensions
    {
        public static ObservableCollection<T> GetAs<T>(this ObservableCollection<object> collection)
        {
            var collectionToReturn= new ObservableCollection<T>();
            foreach (var item in collection)
            {
                collectionToReturn.Add(JsonConvert.DeserializeObject<T>(item.ToString()));
            }
            return collectionToReturn;
        }
    }
}