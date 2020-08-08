using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.ValidationAttributes
{
    public class SameDayConstraintAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                if (date.Date.Day != DateTime.Now.Day)
                    return new ValidationResult(ErrorMessage, new[] { nameof(DateTime) });
            }
            return ValidationResult.Success;
        }
    }
}