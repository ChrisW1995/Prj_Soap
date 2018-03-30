using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace Prj_Soap.Service
{
    public class CustomAuthorization : System.Web.Mvc.AuthorizeAttribute
    {
        public string LoginPage { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated||
                filterContext.HttpContext.User.Identity.IsAuthenticated &&
                filterContext.HttpContext.User.Identity.Name != "Admin" &&
                LoginPage.Contains("Admin"))
            {
                filterContext.HttpContext.Response.Redirect(LoginPage);
            }
            base.OnAuthorization(filterContext);
        }
    }
}