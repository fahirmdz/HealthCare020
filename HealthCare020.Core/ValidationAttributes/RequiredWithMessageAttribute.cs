using System;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Resources;

namespace HealthCare020.Core.ValidationAttributes
{
    public enum InputType
    {
        Input,
        Pick
    }
    /// <summary>
    /// Required constraint with message from main application resource file
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RequiredWithMessage : ValidationAttribute
    {
        public InputType InputType;
        public string PickName { get; set; }

        public RequiredWithMessage(InputType InputType=InputType.Input, string PickName="")
        {
            this.InputType = InputType;
            this.PickName = PickName;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value is string str && string.IsNullOrWhiteSpace(str))
            {
                var errorMessage = SharedResources.RequiredValidationError;

                if (InputType == InputType.Pick)
                {
                    if (!string.IsNullOrWhiteSpace(PickName))
                    {
                        errorMessage = SharedResources.RequiredPickMessage.Replace("#", PickName);
                    }
                    else if (validationContext.MemberName?.ToLower().Contains("Id") ?? false)
                        errorMessage = SharedResources.RequiredPickMessage.Replace("#",
                            validationContext.MemberName.Substring(0,
                                validationContext.MemberName.IndexOf("Id", StringComparison.Ordinal)));
                }


                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}