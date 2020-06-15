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
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }

            return new ValidationResult($"Neispravan format datuma -> {value}");
        }
    }
}