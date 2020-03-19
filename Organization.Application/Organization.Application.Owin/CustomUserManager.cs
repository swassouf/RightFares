using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Organization.Application.Owin.Services;
using Organization.Application.Owin.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Owin
{
    public class CustomUserManager : UserManager<CustomUser>
    {
        public CustomUserManager(IUserStore<CustomUser> store) : base(store)
        {
           // EmailService emailService = new EmailService();
        }
        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            var manager = new CustomUserManager(new CustomUserStore());

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<CustomUser>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<CustomUser>()
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is { 0}"
            });
         
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<CustomUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

         

        //public override Task<CustomUser> FindByNameAsync(string userName)
        //{
        //    return base.FindByNameAsync(userName);
        //}
    }
}
