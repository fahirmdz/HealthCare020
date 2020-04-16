using System.Reflection;
using HealthCare020.Services.Interfaces;

namespace HealthCare020.Services.Services
{
    public class PropertyCheckerService:IPropertyCheckerService
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
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                //it can't be found, return false
                if (propertyInfo == null)
                    return false;
            }

            //properties found, return true
            return true;
        }
    }
}