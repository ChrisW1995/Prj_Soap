using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class CustomerChart
    {
        public int Id { get; set; }

        [Required]
        public string SoapId { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public DateTime AddTime { get; set; }

        public Customers Customers { get; set; }

        public Soap Soap { get; set; }


    }
}