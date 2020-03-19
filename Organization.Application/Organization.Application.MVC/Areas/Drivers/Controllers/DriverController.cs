using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organization.Application.MVC.Areas.Drivers.Controllers
{
    public partial class DriverController : Controller
    {
        // GET: Drivers/Driver
        public virtual ActionResult Default()
        {
            return View();
        }
    }
}