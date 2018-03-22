using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers
{
    [CustomAuthorization(LoginPage = "/Account/Login", Roles = "User")]
    public class CartController : Controller
    {
        private CartService cartService = new CartService();
        // GET: Cart
        public ActionResult Index()
        {
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var list = cartService.GetListInCart(c_id);
            return View(list);
        }
    }
}