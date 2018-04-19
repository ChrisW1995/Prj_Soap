using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Prj_Soap.Models.ViewModels
{
    public class NewsListViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string AddTime { get; set; }
    }

    public class UpdateNewsViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }
    }

    public class CreateNewsViewModel
    {
        [MaxLength(25)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}