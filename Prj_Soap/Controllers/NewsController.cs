using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers
{
    public class NewsController : Controller
    {
        NewsService newsService = new NewsService();
        // GET: News
        public ActionResult Index(int? page)
        {
            var list = newsService.GetNewsList().ToPagedList(page ?? 1, 8);
            return View(list);
        }

    }
}