using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

namespace HealthCore020.Test.Services
{
    public static class HttpContextService
    {
        public static void SetFakeAuthenticatedControllerContext(this ControllerBase controller,List<Claim> claims=null)
        {
            var httpContext = FakeAuthenticatedHttpContext(claims);
            ControllerContext context = new ControllerContext(new ActionContext(httpContext,new RouteData(),new ControllerActionDescriptor()));
            controller.ControllerContext = context;
        }

        private static HttpContext FakeAuthenticatedHttpContext(List<Claim> claims)
        {
            var context = new Mock<HttpContext>();
            var headerDictionary = new Mock<HeaderDictionary>();
            var request = new Mock<HttpRequest>();
            var response = new Mock<HttpResponse>();
            var user = new Mock<ClaimsPrincipal>();
            if (claims != null)
                user.Setup(x => x.Claims).Returns(claims);
            response.Setup(x => x.Headers).Returns(headerDictionary.Object);
            var identity = new Mock<IIdentity>();

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.User).Returns(user.Object);
            user.Setup(ctx => ctx.Identity).Returns(identity.Object);
            identity.Setup(id => id.IsAuthenticated).Returns(true);
            identity.Setup(id => id.Name).Returns("doktoracc");

            return context.Object;
        }
    }
}