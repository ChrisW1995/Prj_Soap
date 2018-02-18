using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Counties
    {
        public int Id { get; set; }

        public string CountyName { get; set; }

        public ICollection<Areas> Areas { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}