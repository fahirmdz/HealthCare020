using System;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.Resources;

namespace HealthCare020.Core.ValidationAttributes
{
    /// <summary>
    /// Minimum and maximum string length constraint with error message from main application resource file
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class StringLengthWithMessage : ValidationAttribute
    {
        public int MinLength { get; }

        public int MaxLength { get; }

        public StringLengthWithMessage(int MinLength, int MaxLength)
        {
            this.MaxLength = MaxLength;
            this.MinLength = MinLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str && (string.IsNullOrWhiteSpace(str) || str.Length < 2 || str.Length > 25))
            {
                return new ValidationResult(SharedResources.StringLengthValidationErrorMask.With(MinLength.ToString(), MaxLength.ToString()));
            }

            return ValidationResult.Success;
        }
    }
}