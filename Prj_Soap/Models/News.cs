using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class News
    {
        [Key, StringLength(20)]
        public string Id { get; set; }

        [StringLength(25)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime AddTime { get; set; }
    }
}