namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            CT_DonDatHang = new HashSet<CT_DonDatHang>();
            CT_PhieuNhap = new HashSet<CT_PhieuNhap>();
            ChiTietSP = new HashSet<ChiTietSP>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int? MaLoaiSP { get; set; }

        public double? GiaNhap { get; set; }

        public double? GiaBan { get; set; }

        [StringLength(50)]
        public string AnhSP { get; set; }

        [StringLength(50)]
        public string AnhCTCon1 { get; set; }

        [StringLength(50)]
        public string AnhCTCon2 { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string ThietKeBoi { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public int? MaNCC { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DonDatHang> CT_DonDatHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuNhap> CT_PhieuNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSP> ChiTietSP { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
