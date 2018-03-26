using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;

namespace Prj_Soap.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        ProductService productService = new ProductService();
        // GET: Admin/Message
        public ActionResult Index(string status)
        {
            var list = productService.GetMessages();

            switch (status)
            {
                case "checked":
                    list = list.Where(x => !string.IsNullOrEmpty(x.ReplyContent));
                    break;
                case "uncheck":
                    list = list.Where(x => string.IsNullOrEmpty(x.ReplyContent));
                    break;

            }


            return View(list);
        }

        [HttpGet]
        public JsonResult GetMessage(int id)
        {
            var msg = productService.GetMessage(id);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Reply(ReplyMessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var result = productService.ReplyMessage(model);

            if (!result.Success)
                TempData["ReplyStatus"] = "alert('Error, 請稍後再試');";

            return RedirectToAction("Index");
        }
    }
}