﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prj_Soap.Service;
using Prj_Soap.Models.DTO;

namespace Prj_Soap.Controllers.Api
{
    public class OrderController : ApiController
    {
        private OrderService orderService = new OrderService();

        [HttpGet]
        public IHttpActionResult GetOrder(string Id)
        {
            var items = orderService.GetOrder(Id);
            if (items.Items.Count() == 0)
                return InternalServerError();
            return Ok(items);
        }

    }
}
