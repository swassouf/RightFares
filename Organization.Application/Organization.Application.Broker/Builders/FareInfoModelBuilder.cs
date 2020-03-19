using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Broker.Builders
{
    public class FareInfoModelBuilder
    {

        public IList<DTO.Dtos.FareInformation> Build(int countryId, int stateId = 14, int cityId = 1)
        {
            var fareBL = ServiceLocator.Current.GetInstance<IFareBL>();
            return fareBL.GetFareInformation(countryId, stateId, cityId);
        }
    }
}
