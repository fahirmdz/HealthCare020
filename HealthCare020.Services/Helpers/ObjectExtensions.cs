using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace HealthCare020.Services.Helpers
{
    public static class ObjectExtensions
    {
        public static ExpandoObject ShapeData<TSource>(this TSource source, string fields)
        {
            if(source==null)
                throw new ArgumentNullException(nameof(source));

            var dataShapedObject = new ExpandoObject();

            if (string.IsNullOrWhiteSpace(fields))
            {
                //all public props in ExpandoObject
                var propertyInfos = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var propertyInfo in propertyInfos)
                {
                    //get the value of the prop on the source obj
                    var propValue = propertyInfo.GetValue(source);

                    //add the field to the ExpandoObject
                    ((IDictionary<string,object>)dataShapedObject).Add(propertyInfo.Name,propValue);
                }

                return dataShapedObject;
            }

            var fieldsAfterSplit = fields.Split(",");

            foreach (var field in fieldsAfterSplit)
            {
                var propName = field.Trim();

                //use reflection to get the property on the source obj
                //need to include public and instance binding flags
                var propertyInfo = typeof(TSource).GetProperty(propName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if(propertyInfo == null)
                    throw new Exception($"Property {propName} wasn't found on {typeof(TSource)}");

                //get the value of the prop on the source obj
                var propertyValue = propertyInfo.GetValue(source);

                ((IDictionary<string,object>)dataShapedObject).Add(propertyInfo.Name,propertyValue);
            }

            return dataShapedObject;
        }
    }
}