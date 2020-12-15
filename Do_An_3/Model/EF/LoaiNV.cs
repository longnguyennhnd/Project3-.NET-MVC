namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiNV")]
    public partial class LoaiNV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiNV()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        [Key]
        public int MaLoaiNV { get; set; }

        [StringLength(50)]
        public string TenLoaiNV { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
