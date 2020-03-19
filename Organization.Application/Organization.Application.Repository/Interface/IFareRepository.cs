using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Repository.Interface
{
    public interface IFareRepository : IRepository<DTO.Entities.City>
    {
        IList<DTO.Dtos.FareInformation> GetFareInformation(int countryId, int stateId, int cityId);
         
    }
}
