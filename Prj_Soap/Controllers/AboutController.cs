using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prj_Soap.Service;
using Prj_Soap.Models.ViewModels;

namespace Prj_Soap.Controllers
{
    public class AboutController : Controller
    {
        AboutService service = new AboutService();
        // GET: About
        public ActionResult Index()
        {
            var model = service.GetAboutSettings();
            var vm = new AboutContentViewModel();
            if(model != null)
            {
                vm.Content = model.Content;
            }
            
            return View(vm);
        }
    }
}