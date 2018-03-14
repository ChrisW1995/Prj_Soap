using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Admin
    {
        [Required, Key]
        [StringLength(25)]
        public string Account { get; set; }

        [Required]
        [StringLength(25)]
        public string Passowrd { get; set; }

        [Required]
        [StringLength(25)]
        public string Adm_Name { get; set; }
    }
}