using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Organization.Application.Business;
using Organization.Application.DTO.Entities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.AspNet.Identity;
using System.Web;
using Moq;
using Organization.Application.MVC.Controllers;
using System.Web.Mvc;

namespace Organization.Application.Test
{
    public class Email
    {
        public Email()
        {
            var container = new UnityContainer();
            IOC.Initialize(container);
            var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        [Fact]
        public void SendEmail()
        {
            Organization.Application.Business.Email.EmailClient email = new Business.Email.EmailClient();


            Person p = new Person
            {
                PrimaryEmail = "sam.wassouf@yahoo.com"
            };

            email.SendEmailConfirmation("1","","");

        }

        [Fact]
        public async Task GenerateSmsToken()
        {
            var controllerCtx = new ControllerContext();
            var httpCtxStub = new Mock<HttpContextBase>();
            controllerCtx.HttpContext = httpCtxStub.Object;

            var controller = new AccountController();

            controller.ControllerContext = controllerCtx;
 
            var userManager = controller.CustomUser;

            var token = await userManager.GenerateTwoFactorTokenAsync("1024", "PhoneCode");
        }
    }
}
