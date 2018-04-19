using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class About
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string Content { get; set; }

        public string FooterContent { get; set; }

        public string FacebookUrl { get; set; }

        public string GoogPlusUrl { get; set; }

        public string TwitterUrl { get; set; }
    }
}