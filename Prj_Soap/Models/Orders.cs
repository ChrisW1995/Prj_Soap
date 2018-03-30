using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Orders
    {
        [Key, StringLength(25)]
        public string Id { get; set; }

        public int TotalPrice { get; set; }

        public string CheckStatus { get; set; }

        public DateTime AddTime { get; set; }

        public DateTime UpdateTime { get; set; }

    }
}