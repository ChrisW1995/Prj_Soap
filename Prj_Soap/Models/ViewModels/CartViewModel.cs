using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models.ViewModels
{

    public class SoapInCartListViewModel
    {
        public int Id { get; set; }

        public string P_Id { get; set; }

        public string ItemName { get; set; }

        public int Price { get; set; }

        public bool IsInStock { get; set; }

        public string ImageUrl { get; set; }

        public int AddCount { get; set; }

        public int TotoalPrice { get; set; }

    }
}