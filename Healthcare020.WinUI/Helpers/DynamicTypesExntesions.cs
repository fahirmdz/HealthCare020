using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Healthcare020.WinUI.Helpers
{
    public static class DynamicTypesExntesions
    {
        public static  DataTable ToDataTable(this IEnumerable<dynamic> items) {
            var data = items.ToArray();
            if (!data.Any()) return null;

            var dt = new DataTable();
            foreach(var key in ((IDictionary<string, object>)data[0]).Keys) {
                dt.Columns.Add(key);
            }
            foreach (var d in data) {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
    }
}