namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhieuNhap = new HashSet<PhieuNhap>();
        }

        [Key]
        public int MaNV { get; set; }

        public int MaLoaiNV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNV { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public DateTime? ThoiGianBDLamViec { get; set; }

        public double? Luong { get; set; }

        public virtual LoaiNV LoaiNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhap { get; set; }
    }
}
