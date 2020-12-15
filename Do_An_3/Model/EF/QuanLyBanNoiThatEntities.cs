namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyBanNoiThatEntities : DbContext
    {
        public QuanLyBanNoiThatEntities()
            : base("name=QuanLyBanNoiThatEntities")
        {
        }

        public virtual DbSet<ClientAccount> ClientAccount { get; set; }
        public virtual DbSet<CT_DonDatHang> CT_DonDatHang { get; set; }
        public virtual DbSet<CT_PhieuNhap> CT_PhieuNhap { get; set; }
        public virtual DbSet<ChiTietSP> ChiTietSP { get; set; }
        public virtual DbSet<DonDatHang> DonDatHang { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiNV> LoaiNV { get; set; }
        public virtual DbSet<LoaiSP> LoaiSP { get; set; }
        public virtual DbSet<Mau> Mau { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuat { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAccount>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ClientAccount>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatHang>()
                .Property(e => e.PhoneNum)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatHang>()
                .HasMany(e => e.CT_DonDatHang)
                .WithRequired(e => e.DonDatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Pass)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiNV>()
                .HasMany(e => e.NhanVien)
                .WithRequired(e => e.LoaiNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSP>()
                .Property(e => e.Hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.Hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.AnhCTCon1)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.AnhCTCon2)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.LinkAnh)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
