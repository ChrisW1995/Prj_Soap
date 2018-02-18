using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models.DTO
{
    public class CreateNewsDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

    }
}