using Prj_Soap.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Prj_Soap.Controllers
{
    public class ProductController : Controller
    {
        SoapService soapService = new SoapService();
        ProductService productService = new ProductService();
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

        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var result = productService.AddToCart(id, c_id);
            if(result.Success == true)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }
    }
}