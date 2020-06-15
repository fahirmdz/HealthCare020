using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.ValidationAttributes
{
    public class GenderAbbrAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is char gender) || (char.ToUpper(gender)!='M' && char.ToUpper(gender)!='Z'))
                return new ValidationResult($"Neispravan format pola. Trebao bi biti 'M' ili 'Z'.");

            return ValidationResult.Success;
        }
    }
}