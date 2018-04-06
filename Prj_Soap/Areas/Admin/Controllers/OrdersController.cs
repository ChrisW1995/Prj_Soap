using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Service;
using PagedList;

namespace Prj_Soap.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private OrderService orderService = new OrderService();
        // GET: Admin/Orders
        public ActionResult Index(int? page)
        {
            var orders = orderService.GetAllOrders().ToPagedList(page ?? 1, 15);
            return View(orders);
        }
    }
}