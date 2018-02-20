using Prj_Soap.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_Soap.Controllers
{
    public class ProductController : Controller
    {
        SoapService soapService = new SoapService();

        // GET: Product
        public ActionResult Index()
        {
            var list = soapService.GetList();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            var instance = soapService.GetSoap(id);
            return View(instance);
        }
    }
}