﻿using Prj_Soap.Models.ViewModels;
using Prj_Soap.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Prj_Soap.Controllers
{
    public class ProductController : Controller
    {
        SoapService soapService = new SoapService();
        ProductService productService = new ProductService();
        // GET: Product
        public ActionResult Index()
        {
            var list = soapService.GetList();
            return View(list);
        }

        public ActionResult AddMessage(NewMessagesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["AddMsg"] = "alert('發問字數為200字內！');";

                return RedirectToAction("Detail", new { id = model.P_Id });
            }
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var result = productService.CreateMessage(c_id, model);
            if (result.Success == false)
                TempData["AddMsg"] = "alert('提問失敗, 請稍後再試');";

            return RedirectToAction("Detail", new { id = model.P_Id });
        }

        public ActionResult Detail(string id, int? page)
        {
            var instance = soapService.GetSoap(id);
            var messageList = productService.GetMessages(id);
            var model = new SoapDetailViewModel()
            {
                Soap = instance,
                Messages = messageList.ToPagedList(page ?? 1, 5)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            var c_id = Request.Cookies["IdCookie"].Values["customer_id"];
            var result = productService.AddToCart(id, c_id);
            if(result.Success == true)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        public ActionResult _AddMessage(string p_id)
        {
            var model = new NewMessagesViewModel
            {
                P_Id = p_id
            };
            return PartialView("_AddMessage", model);
        }
    }
}