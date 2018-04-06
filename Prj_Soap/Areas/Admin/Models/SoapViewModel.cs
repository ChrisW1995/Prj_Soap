using Prj_Soap.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Areas.Admin.Models
{
    public class SoapUploadViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "商品名稱")]
        public string ItemName { get; set; }

        [StringLength(250)]
        public string ItemContent { get; set; }

        [Required]
        [Display(Name = "售價")]
        public int Price { get; set; }

        public int StockCount { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
    
    public class AdminSoapListViewModel
    {
        public IEnumerable<SoapWithFormattedDate> Soaps;

        public int Total;
    }

    public class SoapWithFormattedDate
    {
     
        public string Id { get; set; }

        public string ItemName { get; set; }

        public string ItemContent { get; set; }

        public int Price { get; set; }

        public int StockCount { get; set; }

        public string ImageUrl { get; set; }

        public DateTime UploadTime { get; set; }
        public string FormattedDate => UploadTime.ToString("yyyy/MM/dd HH:mm");
    }
}