using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Healthcare020.Mobile.ViewModels
{
    public class BaseValidationViewModel : BaseViewModel
    {
        /// <summary>
        /// Dictionary with errors based on model validation
        /// </summary>
        public IDictionary<string, string> Errors;

        public BaseValidationViewModel()
        {
            Errors=new Dictionary<string, string>();
        }

        protected virtual bool ValidateProperty(string propertyName, object value)
        {
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null)
                {
                    MemberName = propertyName
                },
                results);

            if (isValid)
            {
                //Remove all errors if property is valid
                if (Errors.Any(x => x.Key == propertyName))
                    Errors.Remove(propertyName);
            }
            else
            {
                //Add errors to dictionary if prop is not valid
                foreach (var error in results)
                {
                    if (!Errors.ContainsKey(propertyName))
                        Errors.Add(propertyName, error.ErrorMessage);
                }
            }

            return isValid;
        }

        /// <summary>
        /// Validate properties with data annotation attributes
        /// </summary>
        /// <returns>Boolean value indicates validation success and list of validation results</returns>
        public virtual (bool IsValid, List<ValidationResult> ValidationResult) ValidateProperties()
        {
            var validationResults = new List<ValidationResult>();
            var contexts = new ValidationContext(this, null, null);
            var isValid = Validator.TryValidateObject(this, contexts, validationResults, true);

            return (isValid, validationResults);
        }
    }
}