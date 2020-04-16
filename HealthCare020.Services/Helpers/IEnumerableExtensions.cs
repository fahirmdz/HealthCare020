using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace HealthCare020.Services.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<ExpandoObject> ShapeData<TSource>(this IEnumerable<TSource> source,
            string fields)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            //new list to hol ExpandoObjects
            var expandoObjectsList = new List<ExpandoObject>();

            //New list with PropertyInfo objects on TSource
            var propertyInfoList = new List<PropertyInfo>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                //all public properties should be in the ExpandoObject
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(",");

                foreach (var field in fieldsAfterSplit)
                {
                    var propertyName = field.Trim();

                    var propertyInfo = typeof(TSource).GetProperty(propertyName,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo == null)
                        throw new Exception($"Property {propertyName} wasn't found on {typeof(TSource)}");

                    //add propertyInfo to list
                    propertyInfoList.Add(propertyInfo);
                }
            }

            //through the source objects
            foreach (TSource sourceObject in source)
            {
                //new ExpandoObject that will hold the selected props and values
                var dataShapedObject = new ExpandoObject();

                foreach (var propertyInfo in propertyInfoList)
                {
                    //GetValue for value of the property on the source object
                    var propertyValue = propertyInfo.GetValue(sourceObject);

                    //add the field to the ExpandoObject
                    ((IDictionary<string, object>)dataShapedObject).Add(propertyInfo.Name, propertyValue);
                }

                //add to the list
                expandoObjectsList.Add(dataShapedObject);
            }

            return expandoObjectsList;
        }
    }
}