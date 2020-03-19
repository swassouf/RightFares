using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Text.RegularExpressions;
using Organization.Application.Broker;
using Organization.Application.Broker.Models;
using Organization.Application.Broker.Builders;
using Organization.Application.Business.Interface;
using Microsoft.Practices.ServiceLocation;
using ConstantsDtos = Organization.Application.DTO.Constants;
using Organization.Application.MVC.Areas.Customers.Controllers;
using Organization.Application.DTO.Entities;
using Organization.Application.Business.Email;
using System.Data.Entity.Utilities;
using Organization.Application.Owin;
using System.Collections.Generic;

namespace Organization.Application.MVC.Controllers
{
    [Authorize]
    public partial class AccountController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //Sam
        //Sam

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async virtual Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            // var token = await CustomUser.GenerateTwoFactorTokenAsync("1024", "Phone Code");


            // ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.TwoFactorCookie);
            // identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1020"));
            // AuthenticationManager.SignIn(identity);

            //return RedirectToAction(Mvc.Account.VerifyCode("EmailTokenProvider", Url.Action(Mvc.Customers.Customer.Default()), false));

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            var user = await CustomUser.FindByNameAsync(model.Email.ToLower().Trim());
            if(user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
            if(!await CustomUser.IsEmailConfirmedAsync(user.Id))
            {
                ModelState.AddModelError("", "You need to confirm your email.");
                return View(model);
            }
        
            var result = await CustomSignIn.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction(Mvc.Account.VerifyCode("Phone Code", Url.Action(Mvc.Home.Index()), false));
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }

        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async virtual Task<ActionResult>  VerifyCode(string provider, string returnUrl, bool rememberMe)
        {

            // Require that the user has already logged in via username/ password or external login
            if (!await CustomSignIn.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            //if (User.Identity.GetUserId() == null)
            //{
            //    return View("Error");
            //}

            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await CustomSignIn.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);

            switch (result)
            {
                case SignInStatus.Success:
                    var userId = await CustomSignIn.GetVerifiedUserIdAsync().WithCurrentCulture();
                    var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();
                    await accountBL.ApproveVerification(Convert.ToInt32(userId));
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    var user = await CustomUser.FindByIdAsync(userId);
                    await CustomSignIn.SignInAsync(user, model.RememberMe, model.RememberBrowser);

                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        [ChildActionOnly]
        public virtual ActionResult Register()
        {
            var builder = new RegisterModelBuilder();
            var model = builder.Build();

            return PartialView(model);
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                CustomUser customUser = model;
                customUser.TwoFactorEnabled = true;

                var user = await CustomUser.FindByNameAsync(model.Email);
                if (user != null && !user.PersonRoles.Any(r => r.RoleId == model.RoleID))
                {
                    //await CustomUser.AddToRoleAsync(user.Id, Enum.GetName(typeof(DTO.Constants.RolesEnum), model.RoleID));
                    //await CustomUser.AddClaimAsync(user.Id, new Claim(ClaimTypes.Role, model.RoleID.ToString()));

                    int existingRoleID = user.PersonRoles.Select(r => r.RoleId).First();
                    var existedRoleName = existingRoleID == ConstantsDtos.Roles.Customer ? "RF Customer" : "RF Driver";
                    var RoleName = model.RoleID == ConstantsDtos.Roles.Customer ? "RF Customer" : "RF Driver";
                    string loginUrl = Url.Action(Mvc.Account.Login());
                    IList<string> message = new List<string>();
                    message.Add(string.Format("We found your email address in our system and you already created an account with us as <strong> {0} </strong>.<br> To create new role please do the following:<ul><ol>Log in to your account.</ol> <ol>Click on Profile link</ol><ol>Click on Add New Role</ol></ul> Click here to go to login page <a class='btn btn-info' href='{loginUrl}'>LogIn</a> ", existedRoleName));

                    TempData["Errors"] = message;

                }
                else
                {
                    var result = await CustomUser.CreateAsync(customUser, model.Password);

                    if (result.Errors.Count() > 0)
                    {
                        // TempData["RegistrationError"] = "We Found you email in out system. Please try to login using your email and password.";
                    }
                    else
                    {
                        var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();

                        string emailCode = await _CustomUserManager.GenerateEmailConfirmationTokenAsync(customUser.Id);
                        string phoneCode = await CustomUser.GenerateTwoFactorTokenAsync(customUser.Id, "Phone Code");
                        await accountBL.SaveMobileGeneratedVerificationCode(customUser.ID, Convert.ToInt32(phoneCode));

                        // var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();
                        EmailTemplate emailTemplate = accountBL.GetEmail("EMAIL_VERIFICATION");

                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = customUser.Id, code = emailCode }, protocol: Request.Url.Scheme);
                        string emailBody = String.Format(emailTemplate.Body, model.FirstName, callbackUrl);
                        await _CustomUserManager.SendEmailAsync(customUser.Id, emailTemplate.Subject, emailBody);
                        //await _CustomUserManager.SendSmsAsync(customUser.Id, "");

                        return View(Mvc.Account.Views.DisplayEmail);

                    }

                    TempData["Errors"] = result.Errors;
                }

            }


            return RedirectToAction(Mvc.Home.Index());
        }



        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public virtual async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await CustomUser.ConfirmEmailAsync(userId, code);

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            if (result.Succeeded)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return RedirectToAction(Mvc.Account.Login());
            }
            else
                return View("Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public virtual ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await CustomUser.FindByNameAsync(model.Email);
                if (user == null || !(await CustomUser.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }
                 

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                 string code = await CustomUser.GeneratePasswordResetTokenAsync(user.Id);
                 var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                 await CustomUser.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                 return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public virtual ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public virtual ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await CustomUser.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await CustomUser.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public virtual ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public virtual async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await CustomSignIn.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await CustomUser.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ActionResult> ResendCode()
        {
            var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();
            var userId = await CustomSignIn.GetVerifiedUserIdAsync().WithCurrentCulture();

            string phoneCode = await CustomUser.GenerateTwoFactorTokenAsync(userId, "Phone Code");
            await accountBL.SaveMobileGeneratedVerificationCode(Convert.ToInt32(userId), Convert.ToInt32(phoneCode));

            return Json(new { });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }



        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}