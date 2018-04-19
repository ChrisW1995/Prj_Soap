using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models.DTO
{
    public class ChangeOrderStatusDTO
    {
        public string OrderId { get; set; }

        public int StatusId { get; set; }
    }

    public class OrderItems
    {
        public string SoapId { get; set; }

        public string ItmeName { get; set; }

        public int ItemPrice { get; set; }

        public int AddCount { get; set; }
    }

    public class OrderStatusList
    {
        public int Id { get; set; }

        public string StatusName { get; set; }
    }

    public class OrderDetailDTO
    {
        public IEnumerable<OrderItems> Items { get; set; }

        public IEnumerable<OrderStatusList> Status { get; set; }

        public string OrderId { get; set; }

        public int StatusId { get; set; }

        public int TotalPrice { get; set; }


    }
}