using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class SanPhamDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public SanPhamDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        public List<Sanpham> LaySP()
        {
            return db.Sanpham.ToList();
        }
        public Sanpham Lay1SP(int? maSP)
        {
            return db.Sanpham.Find(maSP);
        }
        public List<Sanpham> LaySPHome()
        {
            return db.Sanpham.Take(12).ToList();
        }
        public List<Sanpham> LaySPTheoMaLoai(int? Maphong, int? Maloaisp)
        {
            IQueryable<Sanpham> lstsp = db.Sanpham.Where(n => n.MaLoaiSP == Maloaisp);
            return lstsp.ToList();
        }
        public int XoaSPTheoMaLoai(int? maloai)
        {
            Object[] ps =
            {
                new SqlParameter("@malsp", maloai)
            };
            return db.Database.ExecuteSqlCommand("SelectNew", ps);
        }
        public int Insert(Sanpham entity)
        {
            db.Sanpham.Add(entity);
            db.SaveChanges();
            return entity.MaSP;
        }

        public bool Update(Sanpham entity)
        {
            try
            {
                var sp = db.Sanpham.Find(entity.MaSP);
                sp.TenSP = entity.TenSP;
                sp.GiaBan = entity.GiaBan;
                //sp.AnhSP = entity.AnhSP;
                sp.SoLuong = entity.SoLuong;
                sp.TrangThai = entity.TrangThai;
                sp.ThietKeBoi = entity.ThietKeBoi;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Sanpham> ListAllPaging(int page, int pageSize)
        {
            return db.Sanpham.OrderByDescending(x => x.TenSP).ToPagedList(page, pageSize);
        }
        public Sanpham ViewDetail(int? id)
        {
            return db.Sanpham.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var sp = db.Sanpham.Find(id);
                db.Sanpham.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
