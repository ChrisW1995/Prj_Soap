using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Service;
using AutoMapper;
using Prj_Soap.Models;

namespace Prj_Soap.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        AboutService aboutService = new AboutService();
        // GET: Admin/About
        public ActionResult Index() 
        {
            var instance = aboutService.GetAboutSettings();
            return View(instance);
        }

        public ActionResult SaveChange(About model)
        {
            var _model = aboutService.SaveChange(model);
            if (model == null)
            {
                TempData["SaveResutl"] = "alert('儲存失敗! 請稍後再試');";
            }
            TempData["SaveResutl"] = "alert('修改完成');";

            return View("Index", _model);

        }


    }
}