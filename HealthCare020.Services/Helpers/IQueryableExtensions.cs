using HealthCare020.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace HealthCare020.Services.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy,
            Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (mappingDictionary == null)
                throw new ArgumentNullException(nameof(mappingDictionary));

            if (string.IsNullOrWhiteSpace(orderBy))
                return source;

            var orderByString = string.Empty;

            //orderBy string is separeted with ","
            var orderByAfterSplit = orderBy.Split(",");

            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();

                //if the sort option ends with " desc", we order descending, otherwise ascending
                var orderDescending = trimmedOrderByClause.EndsWith(" desc");

                //remove " asc"  or " desc"  from the orderByClause,
                //so we get the property name to look for in the mapping dictionary
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ", StringComparison.Ordinal);
                var propertyName = indexOfFirstSpace == -1
                    ? trimmedOrderByClause
                    : trimmedOrderByClause.Remove(indexOfFirstSpace);

                if (!mappingDictionary.ContainsKey(propertyName))
                    throw new ArgumentNullException($"Key mapping for {propertyName} is missing");

                //get the PropertyMappingValue
                var propertyMappingValue = mappingDictionary[propertyName];

                if (propertyMappingValue == null)
                    throw new ArgumentNullException("Property mapping value not found");

                //Run through the property names
                //so the orderby clauses are applied in the correct order
                foreach (var destinationProperty in propertyMappingValue.DestionationProperties)
                {
                    //revert sort order if neccessary
                    if (propertyMappingValue.Revert)
                    {
                        orderDescending = !orderDescending;
                    }

                    orderByString = orderByString +
                                    (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ")
                                    + destinationProperty
                                    + (orderDescending ? " descending" : " ascending");
                }
            }

            //Order with orderBy method from Linq.Dynamic.Core library with annotation e.g. FirstName asceding

            return source.OrderBy(orderByString);
        }
    }
}