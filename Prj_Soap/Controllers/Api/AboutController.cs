using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers.Api
{
    public class AboutController : ApiController
    {
        AboutService service = new AboutService();

        [HttpGet]
        public IHttpActionResult GetSettings()
        {
            var setting = service.GetAboutSettings();
            if (setting == null)
                return NotFound();


            return Ok(setting);
        }
    }
}
