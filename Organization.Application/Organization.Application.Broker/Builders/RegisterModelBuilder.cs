using Organization.Application.Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Organization.Application.Broker.Builders
{
    public class RegisterModelBuilder
    {
        public RegisterViewModel Build()
        {
            var model = new RegisterViewModel();
            model.RoleOptions = this.GetRoleOptions();
            return model;
        }

        private IList<SelectListItem> GetRoleOptions()
        {
            return new SelectListItem[] { new SelectListItem { Text = "RF Riders", Value = "2" }, new SelectListItem { Text = "RF Drivers", Value = "1" } };
        }
    }
}
