using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Areas
    {
        public int Id { get; set; }

        public int CountyId { get; set; }

        [StringLength(8)]
        public string AreaName { get; set; }

        public Counties Counties { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}