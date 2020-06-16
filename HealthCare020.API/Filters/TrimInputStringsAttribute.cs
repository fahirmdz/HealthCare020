using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HealthCare020.API.Filters
{
    public class TrimInputStringsAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments.ToList())
            {
                if (arg.Value is string)
                {
                    if (arg.Value == null)
                        continue;

                    string val = arg.Value as string;
                    if (!string.IsNullOrEmpty(val))
                    {
                        context.ActionArguments[arg.Key] = val.Trim();
                    }

                    continue;
                }

                var argType = arg.Value.GetType();
                if (!argType.IsClass)
                    continue;

                TrimAllStringsInObject(arg.Value,argType);
            }
        }

        private void TrimAllStringsInObject(object arg, Type argType)
        {
            var stringProps = argType.GetProperties()
                .Where(p => p.PropertyType == typeof(string));

            foreach (var stringProp in stringProps)
            {
                var currentValue = stringProp.GetValue(arg, null) as string;
                if (!string.IsNullOrEmpty(currentValue))
                {
                    stringProp.SetValue(arg,currentValue.Trim(),null);
                }
            }
        }
    }
}