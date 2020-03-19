using Organization.Application.Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organization.Application.MVC.Controllers
{
    public partial class BaseController : Controller
    {
        // GET: Base
        protected CustomUserManager _CustomUserManager;
        protected CustomSignInManager _CustomSignInManager;
        public CustomUserManager CustomUser
        {
            get
            {
                _CustomUserManager = _CustomUserManager ?? HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
                _CustomUserManager.PasswordHasher = new CustomPasswordHasher();
                return _CustomUserManager;
            }
            private set
            {
                _CustomUserManager = value;
            }
        }
        public CustomSignInManager CustomSignIn
        {
            get
            {
                var signIn = _CustomSignInManager ?? HttpContext.GetOwinContext().Get<CustomSignInManager>();
                signIn.UserManager.PasswordHasher = new CustomPasswordHasher();
                return signIn;
            }
            private set
            {
                _CustomSignInManager = value;
            }
        }

    }
}