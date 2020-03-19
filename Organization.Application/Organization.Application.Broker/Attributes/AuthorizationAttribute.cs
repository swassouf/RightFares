using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Routing;
using Organization.Application.Broker.Extentions;

namespace Organization.Application.Broker.Attributes
{
    public class AuthorizationAttribute :  AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool? isVerified = Thread.CurrentPrincipal.Identity.IsCodeVarified();

            if (!isVerified.Value)
            {
                var result = RedirectToVerificationCode(filterContext.RequestContext);
                filterContext.Result = result;
            }
        }

        private RedirectResult RedirectToVerificationCode(RequestContext requestContext)
        {
            UrlHelper urlHelper = new UrlHelper(requestContext);
            string returnUrl = urlHelper.Action("Default", "Customer", new { area = "Customers" });
            RedirectResult redirectResult = new RedirectResult(urlHelper.Action("VerifyCode", "Account", new { area = "", provider = "Email", returnUrl = returnUrl, rememberMe = false }));

            return redirectResult;
        }

    }
}
