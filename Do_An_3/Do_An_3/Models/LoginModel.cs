using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_3.Models
{
    public class LoginModel
    {
        [Key]
        [Display (Name = "Tài khoản")]
        [Required(ErrorMessage ="Bạn chưa nhập tài khoản")]
        public string UserName { get; set; }

        [Display (Name ="Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}