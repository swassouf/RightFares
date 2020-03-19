using Organization.Application.Repository.Context;
using Organization.Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Application.Repository.Implementation
{
    public class FareRepository : Repository<DTO.Entities.City>, IFareRepository
    {

        public IList<DTO.Dtos.FareInformation> GetFareInformation(int countryId, int stateId, int cityId)
        {
            using (var ctx = new DispatchContext())
            {
                var result = (from cr in ctx.CountryRegions
                              join sp in ctx.StateProvinces
                              on cr.ID equals sp.CountryRegionId
                              join c in ctx.Cities
                              on sp.ID equals c.StateProvinceId
                              join totcf in ctx.TransportOptionToCityFarePrices
                              on c.ID equals totcf.CityId
                              join to in ctx.TransportOptions
                              on totcf.TransportOptionId equals to.ID
                              join t in ctx.TransportTypes
                              on to.TransportTypeId equals t.ID
                              where (cr.ID == countryId && sp.ID == stateId && c.ID == cityId)
                              orderby sp.Name, c.Name
                              select new DTO.Dtos.FareInformation
                              {
                                  Country = cr.Name,
                                  State = sp.Name,
                                  City = c.Name,
                                  BaseFare = totcf.BaseFare,
                                  PerMile = totcf.PerMile,
                                  PerMinute = totcf.PerMinute,
                                  TransportType = t.Name,
                                  TransportOption = to.Name

                              }).Distinct();

                return result.ToList();
            }
        }
    }
}
