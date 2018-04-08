using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Areas.Admin.Models
{
    public class AdminOrdersViewModel
    {
        public string Id { get; set; }

        public string CheckStatus { get; set; }

        public string C_Name { get; set; }

        public string C_Phone { get; set; }

        public string C_Email { get; set; }

        public string C_Address { get; set; }

        public DateTime AddTime { get; set; }

        public string FormattedAddTime => AddTime.ToString();

    }
}