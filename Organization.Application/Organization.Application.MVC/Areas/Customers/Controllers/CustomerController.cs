using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Organization.Application.Broker.Attributes;
using System.Security.Claims;
using System.Threading;

namespace Organization.Application.MVC.Areas.Customers.Controllers
{
 
    public partial class CustomerController : BaseCustomerController
    {
        // GET: Customers/Customer

        public virtual ActionResult Default()
        {
  
            return View();
        }
    }
}