using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prj_Soap.Models.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(25), Display(Name = "帳號")]
        [Required(ErrorMessage = "帳號為必填欄位")]
        public string Account { get; set; }

        [Required(ErrorMessage = "密碼為必填欄位"), Display(Name = "密碼")]
        [StringLength(25)]
        public string Password { get; set; }

        [Required(ErrorMessage = "請再次輸入上面設定之密碼")]
        [StringLength(25)]
        [Compare("Password", ErrorMessage = "兩次輸入密碼不一致!")]
        public string CheckPassword { get; set; }

        [Required(ErrorMessage = "姓名為必填欄位")]
        [StringLength(25), Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email為必填欄位")]
        [StringLength(200), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "電話為必填欄位")]
        [StringLength(10), MaxLength(10, ErrorMessage = "電話號碼長度有誤"),MinLength(10, ErrorMessage = "電話號碼長度有誤")]
        [Display(Name = "電話")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "地址為必填欄位")]
        [StringLength(250), Display(Name = "地址")]
        public string DetailAddress { get; set; }

    }

    public class LoginViewModel
    {
        [StringLength(25), Display(Name = "帳號")]
        [Required]
        public string Account { get; set; }

        [Required]
        [StringLength(25)]
        public string Password { get; set; }

    }
}
