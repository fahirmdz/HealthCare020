using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HealthCore020.Test
{
    public static class Helpers
    {
        public static void ValidateViewModel<TViewModel, TController>(this TController controller, TViewModel viewModelToValidate) 
            where TController : ControllerBase
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(viewModelToValidate, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(viewModelToValidate, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty, validationResult.ErrorMessage);
            }
        }
    }
}