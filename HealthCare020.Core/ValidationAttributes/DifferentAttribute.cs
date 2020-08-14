using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace HealthCare020.Core.ValidationAttributes
{
    public class DifferentAttribute:ValidationAttribute
    {
        public DifferentAttribute(string otherProperty)
        {
            OtherProperty = otherProperty ?? throw new ArgumentNullException(nameof(otherProperty));
        }

        public string OtherProperty { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult(Resources.SharedResources.RequiredValidationError);
            }
            if (otherPropertyInfo.GetIndexParameters().Any())
            {
                throw new ArgumentException($"Property {validationContext.ObjectType.FullName} nije pronadjen");
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (Equals(value, otherPropertyValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }

        private string GetDisplayNameForProperty(PropertyInfo property)
        {
            var attributes = CustomAttributeExtensions.GetCustomAttributes(property, true);
            var display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                return display.GetName();
            }

            return OtherProperty;
        }
    }
}