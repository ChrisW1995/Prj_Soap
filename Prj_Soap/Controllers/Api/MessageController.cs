using Prj_Soap.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prj_Soap.Controllers.Api
{
    public class MessageController : ApiController
    {
        ProductService productService = new ProductService();

        [HttpGet]
        public IHttpActionResult GetMessage(int id)
        {
            var msg = productService.GetMessage(id);
            if (msg == null)
                return NotFound();
            return Ok(msg);
        }

        [HttpPost]
        public IHttpActionResult Delete([FromBody]int id)
        {
            var result = productService.DeleteMessage(id);
            if (!result.Success)
                return InternalServerError();

            return Ok();
        }
    }
}
