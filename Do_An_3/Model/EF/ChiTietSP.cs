namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSP")]
    public partial class ChiTietSP
    {
        [Key]
        public int MaCTSP { get; set; }

        public int? MaSP { get; set; }

        public int? Mamau { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public virtual Mau Mau { get; set; }

        public virtual Sanpham Sanpham { get; set; }
    }
}
