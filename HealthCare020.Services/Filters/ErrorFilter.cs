using HealthCare020.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using NLog;

namespace HealthCare020.Services.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var logger = LogManager.GetCurrentClassLogger();
            logger.Error(context.Exception);

            if (context.Exception is NotFoundException)
            {
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (context.Exception is UserException)
            {
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is UnauthorizedException)
            {
                context.ModelState.AddModelError("Unauthorized access", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ForbiddenException)
            {
                context.ModelState.AddModelError("Missing permission for this action", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                context.ModelState.AddModelError("ERROR", $"{context.Exception?.Message??string.Empty} - {context.Exception?.InnerException?.Message??string.Empty}");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Result = new JsonResult(context.ModelState.Values.SelectMany(x => x.Errors));
            base.OnException(context);
        }
    }
}