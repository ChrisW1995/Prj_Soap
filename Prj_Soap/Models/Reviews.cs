using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        public string C_Id { get; set; }

        public string P_Id { get; set; }

        public string Content { get; set; }

        public int Score { get; set; }

        public DateTime AddTime { get; set; }

        public Soap Soap { get; set; }

        public Customers Customer { get; set; }
    }
}