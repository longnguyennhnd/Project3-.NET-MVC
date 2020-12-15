using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_3.Models
{
    public class RegisterModel
    {
        [Key]
        public int AccountID { set; get; }

        [Display(Name="Tài khoản(*)")]
        [Required(ErrorMessage = "Nhập tài khoản")]
        public string UserName { set; get; }
        

        [Display(Name = "Mật khẩu(*)")]
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 kí tự và dài nhất 16 kí tự")]
        public string Password { set; get; }

        [Display(Name = "Họ tên(*)")]
        [Required(ErrorMessage = "Nhập họ tên")]
        public string Name { set; get; }
        

        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }

        [Display(Name = "Email(*)")]
        [Required(ErrorMessage = "Nhập Email")]
        public string Email { set; get; }
        

        [Display(Name = "Phone(*)")]
        [Required(ErrorMessage = "Nhập số điện thoại")]
        public string Phone { set; get; }
        

        [Display(Name = "Xác nhận mật khẩu(*)")]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không đúng!")]
        [Required(ErrorMessage = "Xác nhận lại mật khẩu")]
        public string ConfirmPassword { set; get; }
        

    }
}