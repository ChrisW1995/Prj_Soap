using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class News
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime AddTime { get; set; }
    }
}