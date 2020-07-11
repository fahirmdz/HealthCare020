using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HealthCare020.Core.ValidationAttributes
{
    public class LettersOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return ValidationResult.Success;
                }

                if (str.Any(x => !char.IsLetter(x)))
                    return new ValidationResult(ErrorMessage);

                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}