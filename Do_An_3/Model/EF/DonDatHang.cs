namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            CT_DonDatHang = new HashSet<CT_DonDatHang>();
        }

        [Key]
        public int MaDDH { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string PhoneNum { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? NgayDat { get; set; }

        public DateTime? NgayDuyet { get; set; }

        public DateTime? NgayGiao { get; set; }

        public double? TongTien { get; set; }

        [StringLength(50)]
        public string DiaChiGiaoHang { get; set; }

        public bool? ThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DonDatHang> CT_DonDatHang { get; set; }
    }
}
