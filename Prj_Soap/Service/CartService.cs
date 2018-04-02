using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Service
{
    public class CartService
    {
        IRepository<Carts> repository = new GenericRepository<Carts>(new ApplicationDbContext());
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<SoapInCartListViewModel> GetListInCart(string c_id)
        {
            var list = db.Carts.Where(x => x.CustomerId == c_id && string.IsNullOrEmpty(x.OrderId)).Join(db.Soaps,
                c => c.SoapId,
                s => s.Id,
                (c, s) => new SoapInCartListViewModel
                {
                   Id = c.Id,
                   P_Id = s.Id,
                   ImageUrl = s.ImageUrl,
                   IsInStock = s.IsInStock,
                   Price = s.Price,
                   ItemName = s.ItemName,
                   AddCount = c.AddCount,
                   TotoalPrice = c.AddCount*s.Price
                });
            return list;
        }

        public Carts GetCart(string soapId, string c_Id)
        {
            var instance = repository.Get(x => x.SoapId.Equals(soapId) && x.CustomerId.Equals(c_Id));
            return instance;
        }

        public IResult CheckOut(List<int> Id)
        {
            IResult result = new Result();
            try
            {
                LocalDateTimeService timeService = new LocalDateTimeService();
                Random r = new Random();
                var today = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                string datetimeStr = today.ToString("yyyyMMddHHmmssFFF");
                var orderId = string.Format("{0}{1}", datetimeStr, r.Next(100, 1000));
                var items = db.Carts.Where(x =>Id.Contains(x.Id)).ToList();
                var sumPrice = items.Join(db.Soaps, c => c.SoapId,
                    s => s.Id,(c, s) => new { c,s }).Sum(x => x.c.AddCount * x.s.Price);

                var instance = new Orders
                {
                    AddTime = today,
                    UpdateTime = today,
                    Id = orderId,
                    TotalPrice = sumPrice,
                    CheckStatus = "Process"
                };
                db.Orders.Add(instance);
                items.ForEach(x => x.OrderId = orderId);
                db.SaveChanges();
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.ToString();
                throw;
            }
            return result;
        }

    }
}