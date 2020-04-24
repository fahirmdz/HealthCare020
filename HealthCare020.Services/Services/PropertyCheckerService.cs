using HealthCare020.Services.Interfaces;
using System;
using System.Reflection;

namespace HealthCare020.Services.Services
{
    public class PropertyCheckerService : IPropertyCheckerService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
                return true;

            //split fields separeted with ","
            var fieldsAfterSplit = fields.Split(",");

            //check if the requested fields exist on source
            foreach (var field in fieldsAfterSplit)
            {
                //trim each field
                var propertyName = field.Trim();

                //check property on T using reflection
                var propertyInfo = typeof(T).GetProperty(propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                //it can't be found, check with nested properties, otherwise return false
                if (propertyInfo == null)
                {
                    var nestedProperties = typeof(T).GetProperties();
                    var fieldInfos = field.Split(".");
                    if (fieldInfos.Length < 2)
                        return false;

                    var parentFieldName = fieldInfos[0];
                    var childFieldName = fieldInfos[1];

                    if (string.IsNullOrWhiteSpace(parentFieldName) || string.IsNullOrWhiteSpace(childFieldName))
                        return false;

                    bool flag = false;
                    foreach (var propInfo in nestedProperties)
                    {
                            var nestedPropOfParent = propInfo.PropertyType.GetProperty(childFieldName,
                                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                            //properties found, return true
                            if (nestedPropOfParent != null)
                                flag = true;
                    }

                    if (!flag)
                        return false;
                }
            }

            return true;
        }
    }
}