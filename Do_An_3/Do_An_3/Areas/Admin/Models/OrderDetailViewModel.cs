using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Do_An_3.Areas.Admin.Models
{
    public class OrderDetailViewModel
    {
        public string Ten { get; set; }
        public int? SoLuong { get; set; }
        public string Anh { get; set; }
        public double? DonGia { get; set; }
        public double? TongTien { get; set; }
    }
}