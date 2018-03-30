using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prj_Soap.Models;
using Prj_Soap.Models.DTO;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers.Api
{
    public class CartController : ApiController
    {
        private ProductService productService = new ProductService();

        [HttpPost]
        public IHttpActionResult UpdateCount(UpdateAddCountDTO model)
        {
            var result = productService.ChangeItemCount(model);
            if (!result.Success)
                return BadRequest();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete([FromBody] int id)
        {
            var result = productService.DeleteCart(id);
            if (!result.Success)
                return BadRequest();
            return Ok();
        }
    }
}
