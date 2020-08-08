using HealthCare020.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.ValidationAttributes
{
    public class FutureDateTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                if (date.Date < DateTime.Now.Date)
                {
                    return new ValidationResult(string.IsNullOrWhiteSpace(ErrorMessage) ? SharedResources.FutureDateTimeConstraintMessage : ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}