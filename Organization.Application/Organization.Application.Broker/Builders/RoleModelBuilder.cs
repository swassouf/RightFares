using Organization.Application.Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Interface;

namespace Organization.Application.Broker.Builders
{
    public class RoleModelBuilder
    {
        public RoleModelBuilder()
        {

        }

        public async Task<RoleViewModel> Build()
        {
            var commonBL = ServiceLocator.Current.GetInstance<ICommonBL<DTO.Entities.Role>>();
            var accountBL = ServiceLocator.Current.GetInstance<IAccountBL>();

            var model = new RoleViewModel();

            model.UserRoles = await accountBL.GetUserRolesByName(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            model.Roles = commonBL.GetALL();

            return model;
        }
    }
}
