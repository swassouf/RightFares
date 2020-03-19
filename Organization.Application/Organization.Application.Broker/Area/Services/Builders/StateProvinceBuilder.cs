using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Broker.Area.Services.Builders
{
  public  class StateProvinceBuilder
    {

        ICommonBL<DTO.Entities.StateProvince> _CommonBL;
        public StateProvinceBuilder()
        {
            this._CommonBL = ServiceLocator.Current.GetInstance<ICommonBL<DTO.Entities.StateProvince>>();
        }

        public List<DTO.Entities.StateProvince> Build(int countryId)
        {
            return this._CommonBL.GetALL().Where(s=>s.CountryRegionId == countryId).ToList();
        }
    }
}
