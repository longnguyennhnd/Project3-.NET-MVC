namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhieuNhap
    {
        [Key]
        public int MaCTPN { get; set; }

        public int? MaSP { get; set; }

        public int? MaPN { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? TongTien { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
