using Microsoft.Practices.ServiceLocation;
using Organization.Application.Business.Implementation;
using Organization.Application.Business.Interface;
using Organization.Application.Broker.Areas.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organization.Application.Broker.Areas.Services.ModelBuilders
{
    public class CountryOptionBuilder
    {
        ICommonBL<DTO.Entities.CountryRegion> _CommonBL;
        public CountryOptionBuilder()
        {
            this._CommonBL = ServiceLocator.Current.GetInstance<ICommonBL<DTO.Entities.CountryRegion>>();
        }

        public List<DTO.Entities.CountryRegion> Build()
        {
            return this._CommonBL.GetALL().ToList();
        }
    }
}