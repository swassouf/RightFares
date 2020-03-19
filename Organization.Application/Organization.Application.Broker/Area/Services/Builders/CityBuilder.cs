using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Broker.Area.Services.Builders
{
    public class CityBuilder
    {
        ICommonBL<DTO.Entities.City> _CommonBL;
        public CityBuilder()
        {
            this._CommonBL = ServiceLocator.Current.GetInstance<ICommonBL<DTO.Entities.City>>();
        }

        public List<DTO.Entities.City> Build(int stateId)
        {
            return this._CommonBL.GetALL().Where(s => s.StateProvinceId == stateId).ToList();
        }
    }
}
