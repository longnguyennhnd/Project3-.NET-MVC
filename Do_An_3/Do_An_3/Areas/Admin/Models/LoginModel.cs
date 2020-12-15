using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Do_An_3.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập user name!")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Mời nhập password!")]
        public string passWord { get; set; }

        public bool RememberMe { get; set; }

    }
}