using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;

namespace Prj_Soap.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        NewsService newsService = new NewsService();
        // GET: Admin/News
        public ActionResult Index(int? page)
        {
            var list = newsService.GetNewsList().ToPagedList(page ?? 1, 3);
            return View(list);
        }

        [HttpPost]
        public ActionResult UpdateNews(UpdateNewsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "alert('編輯欄位不能為空，請重新確認');";
                return RedirectToAction("Index");
            }

            var result = newsService.UpdateNews(vm);
            if (!result.Success)
            {
                TempData["msg"] = "alert('Error');";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "alert('修改完成');";
            return RedirectToAction("Index");
        }
    }
}