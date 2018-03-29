using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public string OrderId { get; set; }

        public string ItemName { get; set; }

        public string AddCount { get; set; }

        public Orders Order { get; set; }

    }
}