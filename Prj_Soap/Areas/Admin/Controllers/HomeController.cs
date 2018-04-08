using Prj_Soap.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Areas.Admin.Models;
using System.Web.Security;

namespace Prj_Soap.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        AccountService accountService = new AccountService();

        // GET: Admin/Home
        [CustomAuthorization(LoginPage = "~/Admin/Home/Login", Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginViewModel model, string returnUrl)
        {
            var admin = accountService.AdminLogin(model.Account, model.Password);

            if(admin != null)
            {
                LocalDateTimeService timeService = new LocalDateTimeService();
                var today = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                var name = admin.Adm_Name;
                HttpContext.Session.Clear();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    name,
                    today,
                    DateTime.Now.AddHours(24),
                    false,
                    "Admin"
                    );

                string enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                return Redirect("/Admin/Soap");
            }

            TempData["loginFail"] = "帳號或密碼錯誤！";
            return View();
        }
    }

}