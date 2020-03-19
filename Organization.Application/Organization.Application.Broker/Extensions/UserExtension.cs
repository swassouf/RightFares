using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Organization.Application.Broker.Extentions
{
    public static class UserExtension
    {
        public static bool IsCodeVarified(this IIdentity identity)
        {
            ClaimsPrincipal icp = Thread.CurrentPrincipal as ClaimsPrincipal;
            // Access IClaimsIdentity which contains claims
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)icp.Identity;

            bool? isVerified = Convert.ToBoolean(Convert.ToInt16(claimsIdentity.FindFirstValue("Verification")));

            return isVerified ?? false;
        }
    }

}