using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prj_Soap.Interface;
using Prj_Soap.Repository;
using Prj_Soap.Models;
using Prj_Soap.Areas.Admin.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Models.DTO;
using AutoMapper;

namespace Prj_Soap.Service
{
    
    public class OrderService
    {
        private IRepository<Orders> orderRepo = new GenericRepository<Orders>(new ApplicationDbContext());
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<AdminOrdersViewModel> GetAllOrders()
        {
            var orders = db.Orders.Join(db.OrderStatus,
                o => o.StatusId,
                os => os.Id,
                (o, os) => new { o, os}).Join(db.Customers,
                oos => oos.o.C_Id,
                c => c.Id,
                (oos, c) => new AdminOrdersViewModel{
                    Id = oos.o.Id,
                    C_Name = c.Name,
                    C_Phone = c.Phone,
                    C_Email = c.Email,
                    C_Address = c.DetailAddress,
                    AddTime = oos.o.AddTime,
                    CheckStatus = oos.os.StatusName
                }).OrderByDescending(x=>x.AddTime).ToList();

            return orders;
            
        }

        public OrderDetailDTO GetOrder(string id)
        {
            var statusId = db.Orders.Where(x => x.Id == id).SingleOrDefault().StatusId;
            var items = db.Carts.Where(x => x.OrderId.Equals(id)).Join(db.Soaps,
                c => c.SoapId,
                s => s.Id,
                (c, s) => new OrderItems {
                    SoapId = s.Id,
                    ItmeName = s.ItemName,
                    ItemPrice = s.Price,
                    AddCount = c.AddCount
                }).ToList();

            var detail = new OrderDetailDTO
            {
                Items = items,
                TotalPrice = items.Sum(x => x.ItemPrice * x.AddCount),
                OrderId = id,
                StatusId = statusId,
                Status = db.OrderStatus.Select(Mapper.Map<OrderStatus, OrderStatusList>)
            };
            return detail;
        }

        public IResult ChangeStatus(string orderId, int statusId)
        {
            IResult result = new Result();
            try
            {
                var order = orderRepo.Get(x => x.Id == orderId);
                order.StatusId = statusId;
                orderRepo.Update(order);
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