using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prj_Soap.Models.DTO;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers.Api
{
    public class SoapController : ApiController
    {
        SoapService soapService = new SoapService();

        [HttpGet]
        public IHttpActionResult GetCatgories()
        {
            var list = soapService.GetCategories();
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult NewCategory(NewCategory model)
        {
            if (model.Name.Length > 15)
                return BadRequest("類別名稱上限為15字!");
            var category = soapService.AddCategory(model.Name);
            if (category == null)
                return InternalServerError();
            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult DelCategory([FromBody] int id)
        {
            var result = soapService.DelCategory(id);
            if (!result.Success)
                return BadRequest();
            return Ok();
        }
    }
}
