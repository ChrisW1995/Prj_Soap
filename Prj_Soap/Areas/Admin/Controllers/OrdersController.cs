using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Service;
using PagedList;

namespace Prj_Soap.Areas.Admin.Controllers
{
    [CustomAuthorization(LoginPage = "~/Admin/Home/Login", Roles = "Admin")]
    public class OrdersController : Controller
    {
        private OrderService orderService = new OrderService();
        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View();
        }
    }
}