using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Carts
    {
        public int Id { get; set; }

        public string SoapId { get; set; }

        public string CustomerId { get; set; }

        [Required]
        public int AddCount { get; set; }

        public DateTime AddTime { get; set; }

        public Soap Soap { get; set; }

        public Customers Customer { get; set; }

    }
}