using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using System.Security.Claims;

namespace Organization.Application.Owin
{
    public class CustomSignInManager : SignInManager<CustomUser, string>
    {
        public CustomSignInManager(CustomUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(CustomUser user)
        {
            return user.GenerateUserIdentityAsync((CustomUserManager)UserManager);
        }

        public static CustomSignInManager Create(IdentityFactoryOptions<CustomSignInManager> options, IOwinContext context)
        {
            return new CustomSignInManager(context.GetUserManager<CustomUserManager>(), context.Authentication);
        }
    }
}
