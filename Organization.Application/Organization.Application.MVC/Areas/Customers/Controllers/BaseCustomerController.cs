using Organization.Application.Broker.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Organization.Application.Broker.Extentions;

namespace Organization.Application.MVC.Areas.Customers.Controllers
{

    [Authorization]
    public partial class BaseCustomerController : Controller
    {
        // GET: Customers/BaseCustomer
        public virtual ActionResult Index()
        {
          
            return View();
        }
    }
}