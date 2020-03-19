using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Interface
{
    public interface IFareBL
    {
        IList<DTO.Dtos.FareInformation> GetFareInformation(int countryId, int stateId = 14, int cityId = 1);
    }
}
