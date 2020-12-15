namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [StringLength(16)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }
    }
}
