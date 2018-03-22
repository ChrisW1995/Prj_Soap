using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public string C_Id { get; set; }

        public string P_Id { get; set; }

        [StringLength(200)]
        public string Content { get; set; }

        [StringLength(200)]
        public string ReplyContent { get; set; }

        public DateTime AddTime { get; set; }

        public Customers Customer { get; set; }

        public Soap Soap { get; set; }

    }
}