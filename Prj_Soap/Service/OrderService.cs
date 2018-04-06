using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prj_Soap.Interface;
using Prj_Soap.Repository;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;

namespace Prj_Soap.Service
{
    
    public class OrderService
    {
        private IRepository<Orders> orderRepo = new GenericRepository<Orders>(new ApplicationDbContext());
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<OrderHistoryViewModel> GetAllOrders()
        {
            var orders = db.Orders.Join(db.OrderStatus,
                o => o.StatusId,
                os => os.Id,
                (o, os) => new OrderHistoryViewModel {
                    OrderId = o.Id,
                    Sum = o.TotalPrice,
                    AddTime = o.AddTime,
                    CheckStatus = os.StatusName,
                    UpdateTime = o.UpdateTime
                }).OrderByDescending(x => x.AddTime).ToList(); ;

            return orders;
            
        }
    }
}