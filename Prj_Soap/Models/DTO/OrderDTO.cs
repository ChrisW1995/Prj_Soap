using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models.DTO
{
    public class OrderItems
    {
        public string SoapId { get; set; }

        public string ItmeName { get; set; }

        public int ItemPrice { get; set; }

        public int AddCount { get; set; }
    }

    public class OrderDetailDTO
    {
        public IEnumerable<OrderItems> Items;

        public string OrderId { get; set; }

        public int TotalPrice { get; set; }


    }
}