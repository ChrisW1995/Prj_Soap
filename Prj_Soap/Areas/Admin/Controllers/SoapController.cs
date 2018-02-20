using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Areas.Admin.Models;
using Prj_Soap.Service;
using System.Net;

namespace Prj_Soap.Areas.Admin.Controllers
{
    public class SoapController : Controller
    {
        SoapService soapService = new SoapService();
        // GET: Admin/Soap
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetSoapList(int page)
        {
            var list = soapService.GetList(page);
            if (list != null)
            {
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SoapUpload(SoapUploadViewModel model)
        {
         
            var serverPath = Server.MapPath("/Upload/Soap/");
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            var soap = soapService.SaveItem(model, serverPath);
            
            if(soap == null)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
            return Json(soap, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteSoap(string id)
        {
            var result = soapService.Delete(id);
            if (result.Success == true)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
        }
    }
}