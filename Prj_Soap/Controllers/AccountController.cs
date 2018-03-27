using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;
using AutoMapper;
using Prj_Soap.Models;

namespace Prj_Soap.Controllers
{
   
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();
        private ProductService productService = new ProductService();
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
                    "User"
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

        
        public ActionResult SignOut()
        {
            Response.Cookies.Clear();
            FormsAuthentication.SignOut();
            if (Request.Cookies["IdCookie"] != null)
            {
                var c = new HttpCookie("IdCookie");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Login");
        }

        [CustomAuthorization(LoginPage = "/Account/Login", Roles = "User")]
        public ActionResult Profile()
        {
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var account = Mapper.Map<Customers, EditProfileViewModel>(accountService.GetAccount(c_id));
            return View(account);
        }

        public ActionResult EditProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Profile");
            }
            var result = accountService.UpdateProfile(model);
            if (!result.Success)
            {
                TempData["profileStatus"] = "alert('修改失敗，請稍後再試');";
            }
            else
            {
                TempData["profileStatus"] = "alert('修改完成');";
            }



            return RedirectToAction("Profile");
        }

        public ActionResult AccountInfo()
        {
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var account = Mapper.Map<Customers, EditAccountViewModel>(accountService.GetAccount(c_id));
            return View(account);

        }

        public ActionResult SaveAccountChange(EditAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("AccountInfo");

            }

            var result = accountService.SaveAccountChange(model);
            if (!result.Success)
            {
                TempData["accStatus"] = "alert('修改失敗')";
            }

            TempData["accStatus"] = "alert('修改完成，下次請以新密碼登入')";

            return RedirectToAction("AccountInfo");
        }

        [CustomAuthorization(LoginPage = "/Account/Login", Roles = "User")]
        public ActionResult Messages()
        {
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var list = productService.GetUserMessages(c_id);
            return View(list);
        }
        
    }
}