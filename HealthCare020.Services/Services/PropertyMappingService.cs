using HealthCare020.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthCare020.Services.Services
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly ICollection<IPropertyMapping> PropertyMapping;


        public PropertyMappingService()
        {
            PropertyMapping = Helpers.PropertyMappingSchema.PropertyMappings;
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            //get matching mapping
            var matchingMapping = PropertyMapping.OfType<PropertyMapping<TSource, TDestination>>();

            var propertyMappings = matchingMapping.ToList();
            if (propertyMappings.Count == 1)
            {
                return propertyMappings.First().MappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping instance for <{typeof(TSource)},{typeof(TDestination)}>");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
                return true;

            var fieldsAfterSplit = fields.Split(",");

            foreach (var field in fieldsAfterSplit)
            {
                var trimmedField = field.Trim();

                //remove everything after first " " (space)
                var indexOfFirstSpace = trimmedField.IndexOf(" ", StringComparison.Ordinal);

                var propertyName = indexOfFirstSpace == -1 ? trimmedField : trimmedField.Remove(indexOfFirstSpace);

                //find matching property
                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }

            return true;
        }
    }
}