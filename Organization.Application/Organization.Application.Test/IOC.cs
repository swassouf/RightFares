using Microsoft.Practices.Unity;
using Organization.Application.Business.Implementation;
using Organization.Application.Business.Interface;
using Organization.Application.Repository.Implementation;
using Organization.Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Test
{
    public static class IOC
    {
        public static void Initialize(IUnityContainer container)
        {
            container = container ?? new UnityContainer();

            //Repository
            container.RegisterType<IAccountRepository, AccountRepository>();

            //Business
            container.RegisterType<IAccountBL, AccountBL>();

        }
    }
}
