using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(15)]
        public string CategoryName { get; set; }
        
    }
}