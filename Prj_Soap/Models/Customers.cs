using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models
{
    public class Customers
    {
        [Key]
        [StringLength(25)]
        public string Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Account { get; set; }

        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string DetailAddress  { get; set; }

        [Required]
        public bool Flg { get; set; }

        [Required]
        public DateTime SignUpTime { get; set; }

        public ICollection<Carts> Carts { get; set; }

    }
}