using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using HealthCare020.Services.Exceptions;

namespace HealthCare020.Services.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UserException)
            {
                if (context.Exception is NotFoundException)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ModelState.AddModelError("ERROR", "Greska na serveru");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(context.ModelState);
        }
    }
}