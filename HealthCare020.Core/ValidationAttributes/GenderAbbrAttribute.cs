using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Resources;

namespace HealthCare020.Core.ValidationAttributes
{
    public class GenderAbbrAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is char gender) || (char.ToUpper(gender)!='M' && char.ToUpper(gender)!='Z'))
                return new ValidationResult(SharedResources.InvalidGenderFormatMessage);

            return ValidationResult.Success;
        }
    }
}