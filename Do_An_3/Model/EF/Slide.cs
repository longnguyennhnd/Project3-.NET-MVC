namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int MaSlide { get; set; }

        [Column(TypeName = "ntext")]
        public string Tieude { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [Column(TypeName = "text")]
        public string LinkAnh { get; set; }
    }
}
