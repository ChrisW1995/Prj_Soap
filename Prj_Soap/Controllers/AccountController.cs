using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;

namespace Prj_Soap.Controllers
{
   
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();
        // GET: Account
        public ActionResult Registe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registe(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                var new_vm = InitRegisterViewModel(vm);
                return View(new_vm);

            }
            var result = accountService.RegisteMember(vm);
            if (result.Success)
            {
                TempData["RegisteResult"] = "";
                return View("RegisteResult");
            }
            TempData["RegisteError"] = $"alert('{result.Message}')";
            return View(InitRegisterViewModel(vm));
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            var customer = accountService.Login(vm);
            if (customer != null)
            {
                LocalDateTimeService timeService = new LocalDateTimeService();
                var today = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                var name = customer.Name;
                HttpContext.Session.Clear();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    name,
                    today,
                    DateTime.Now.AddHours(24),
                    false,
                    "User",
                    FormsAuthentication.FormsCookiePath
                    );

                var idCookie = new HttpCookie("IdCookie");
                idCookie.Expires.AddHours(24);
                idCookie.Values.Add("customer_id", customer.Id);
                //Encrypt cookie
                string enTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
                Response.Cookies.Add(idCookie);

                //string decodedUrl = "";
                //if (!string.IsNullOrEmpty(returnUrl))
                //    decodedUrl = Server.UrlDecode(returnUrl);

                ////Login logic...

                //if (Url.IsLocalUrl(decodedUrl))
                //{
                //    return Redirect(decodedUrl);
                //}

                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("Password", "帳號或密碼錯誤，請重新確認");
            return View(vm);
        }

        public RegisterViewModel InitRegisterViewModel(RegisterViewModel vm)
        {
            var registVM = new RegisterViewModel()
            {
                Account = vm.Account,
                Name = vm.Name,
                Phone = vm.Phone,
                DetailAddress = vm.DetailAddress,
                Email = vm.Email
            };
            return registVM;
        }
        public ActionResult Login()
        {
            return View();
        }

        [CustomAuthorization(LoginPage = "/Account/Login")]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [CustomAuthorization(LoginPage = "/Account/Login")]
        public ActionResult Info()
        {
            return View();
        }
    }
}