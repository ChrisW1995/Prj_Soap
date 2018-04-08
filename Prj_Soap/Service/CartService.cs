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
                   StockCount = s.StockCount,
                   Price = s.Price,
                   ItemName = s.ItemName,
                   AddCount = c.AddCount,
                   TotoalPrice = c.AddCount*s.Price
                });
            return list;
        }

        public Carts GetCart(string soapId, string c_Id)
        {
            var instance = repository.Get(x => x.SoapId.Equals(soapId) && x.CustomerId.Equals(c_Id) && string.IsNullOrEmpty(x.OrderId));
            return instance;
        }

        /// <summary>
        /// If there have any stock count equal zero  
        /// </summary>
        /// <param name="carts"></param>
        /// <returns>true</returns>
        public bool CheckItemStock(IEnumerable<Carts> carts)
        {
            var instance = carts.Join(db.Soaps, c => c.SoapId,
                s => s.Id,
                (c, s) => new { c, s}).Where(x => x.s.StockCount == 0).ToList();
            return instance.Count == 0;
        }

        public IResult CheckOut(List<int> Id, string c_id)
        {
            IResult result = new Result();
            try
            {
                LocalDateTimeService timeService = new LocalDateTimeService();
                Random r = new Random();
                var today = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                string datetimeStr = today.ToString("yyyyMMddHHmmss");
                var orderId = string.Format("{0}{1}", datetimeStr, r.Next(1000, 10000));
                var items = db.Carts.Where(x =>Id.Contains(x.Id)).ToList();
                if (!CheckItemStock(items))
                {
                    result.Message = "有商品庫存不足，請下單前確認庫存量是否足夠";
                    return result;
                }
                var cartsWithSoapList = items.Join(db.Soaps, c => c.SoapId,
                    s => s.Id,(c, s) => new { c,s }).ToList();
                var sumPrice = cartsWithSoapList.Sum(x => x.c.AddCount * x.s.Price);

                var instance = new Orders
                {
                    AddTime = today,
                    UpdateTime = today,
                    Id = orderId,
                    TotalPrice = sumPrice,
                    StatusId = 1,
                    C_Id = c_id
                };
                db.Orders.Add(instance);
                bool stockNotEnough = cartsWithSoapList.Where(x => x.s.StockCount - x.c.AddCount < 0).SingleOrDefault() != null;
                if(stockNotEnough)
                {
                    result.Message = "有商品庫存不足，請下單前確認庫存量是否足夠";
                    return result;
                }
                cartsWithSoapList.ForEach(x => x.s.StockCount = x.s.StockCount - x.c.AddCount);
                items.ForEach(x => x.OrderId = orderId);
                db.SaveChanges();
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = "系統錯誤，請稍後再試";
                throw;
            }
            return result;
        }

    }
}