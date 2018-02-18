using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers
{
    public class HomeController : Controller
    {
        NewsService newsService = new NewsService();
        SoapService soapService = new SoapService();
        public ActionResult Index(int? page)
        {
            var list = newsService.GetNewsList().ToPagedList(page ?? 1, 8);
            return View(list);
        }

        public ActionResult GetNewestSoaps()
        {
            var list = soapService.GetNewest4Items();
            return PartialView("_NewestSoap", list);
        }
    }
}