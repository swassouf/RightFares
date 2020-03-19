using Organization.Application.Broker.Area.Services.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Organization.Application.MVC.Areas.Services.Controllers
{
    public partial class CommonController : Controller
    {

        [HttpGet]
        public virtual JsonResult GetCountries()
        {
            var builder = new Broker.Areas.Services.ModelBuilders.CountryOptionBuilder();
            var model = builder.Build();

            return Json(model.Select(x => new { Value = x.ID, Text = x.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual JsonResult GetStateProvinces(int countryId)
        {
            var builder = new StateProvinceBuilder();
            var model = builder.Build(countryId);
            return Json(model.Select(x => new { Value = x.ID, Text = x.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual JsonResult GetCities(int stateId)
        {
            var builder = new CityBuilder();
            var model = builder.Build(stateId);
            return Json(model.Select(x => new { Value = x.ID, Text = x.Name }), JsonRequestBehavior.AllowGet);
        }

        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}