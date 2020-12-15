namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DonDatHang
    {
        [Key]
        public int MaCTPX { get; set; }

        public int MaDDH { get; set; }

        public int? MaSP { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? TongTien { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
