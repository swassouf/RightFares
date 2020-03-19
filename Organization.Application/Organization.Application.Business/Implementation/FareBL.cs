using Organization.Application.Business.Interface;
using Organization.Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Business.Implementation
{
   public class FareBL: IFareBL
    {
       IFareRepository _FareRepository;

       public FareBL(IFareRepository fareRepository)
       {
           this._FareRepository = fareRepository;
       }

       public IList<DTO.Dtos.FareInformation> GetFareInformation(int countryId, int stateId, int cityId)
       {
           return this._FareRepository.GetFareInformation(countryId, stateId, cityId);
       }
    }
}
