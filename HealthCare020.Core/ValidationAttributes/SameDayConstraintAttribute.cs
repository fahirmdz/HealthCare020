using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.ValidationAttributes
{
    public class SameDayConstraintAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)validationContext.ObjectInstance;

            if (date.Date != DateTime.Now.Date)
            {
                return new ValidationResult(ErrorMessage, new[] { nameof(DateTime) });
            }

            return ValidationResult.Success;
        }
    }
}