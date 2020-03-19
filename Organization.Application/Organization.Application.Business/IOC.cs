using Microsoft.Practices.Unity;
using Organization.Application.Business.Implementation;
using Organization.Application.Business.Interface;
using Organization.Application.Repository.Implementation;
using Organization.Application.Repository.Interface;

namespace Organization.Application.Business
{
    public static class IOC
    {
        public static void Initialize(IUnityContainer container)
        {
            container = container ?? new UnityContainer();

            //Repository
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IFareRepository, FareRepository>();
            //Business
            container.RegisterType<IAccountBL, AccountBL>();
            container.RegisterType<IRoleBL, RoleBL>();
            container.RegisterType<IFareBL, FareBL>();
            container.RegisterType(typeof(ICommonBL<>), typeof(CommonBL<>));
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
