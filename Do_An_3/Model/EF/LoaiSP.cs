namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSP")]
    public partial class LoaiSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiSP()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        [Key]
        public int MaLoaiSP { get; set; }

        [StringLength(50)]
        public string TenLoai { get; set; }

        public int? MaLoaiPhong { get; set; }

        [StringLength(50)]
        public string Hinhanh { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        public int? Tieubieu { get; set; }

        public virtual Phong Phong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
