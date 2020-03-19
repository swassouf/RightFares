using Organization.Application.Broker.Builders;
using Organization.Application.Broker.Models;
using Constants= Organization.Application.DTO.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organization.Application.MVC.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index(HomeViewModel model = null)
        {
            if (User.IsInRole(Constants.Roles.Customer.ToString()))
            {
                return RedirectToAction(Mvc.Customers.Customer.Default());
            }
            else if (User.IsInRole(Constants.Roles.Deriver.ToString()))
            {
                return RedirectToAction(Mvc.Drivers.Driver.Default());
            }

            return View(model);
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public virtual ActionResult FareInformation(int countryId = 238, int stateId = 14, int cityId = 1) // United State we need Enum
        {
            var builder = new FareInfoModelBuilder();
            var model = builder.Build(countryId, stateId, cityId);
            return PartialView(model);
        }
    }
}