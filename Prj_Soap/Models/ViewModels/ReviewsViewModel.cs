using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models.ViewModels
{
    public class SoapReviewsViewModel
    {
        public string Content { get; set; }

        public string C_Name { get; set; }

        public DateTime AddTime { get; set; }

        public string FormattedAddTime => AddTime.ToString("yyyy/MM/dd HH:mm");

        public int Score { get; set; }

    }

    public class ReviewContentViewModel
    {
        public string P_Id { get; set; }

        [Required]
        public int Score { get; set; }

        public string Content { get; set; }
    }
}