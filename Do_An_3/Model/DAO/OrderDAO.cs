using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public OrderDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        public List<DonDatHang> LayDonHangChuaThanhToan()
        {
            return db.DonDatHang.Where(n => n.ThanhToan == false).OrderBy(n => n.NgayDat).ToList();
        }
        public List<DonDatHang> LayDonHangDaThanhToan()
        {
            return db.DonDatHang.Where(n => n.ThanhToan == true).OrderBy(n => n.NgayDat).ToList();
        }
        public IEnumerable<DonDatHang> ListAllPaging(int page, int pageSize)
        {
            return db.DonDatHang.OrderByDescending(x => x.NgayDat).ToPagedList(page, pageSize);
        }
        public void LuuDH(int? id, string TrangThai)
        {
            var dh = db.DonDatHang.Find(id);
            dh.TrangThai = TrangThai;
            if(dh.TrangThai == "Đã thanh toán")
            {
                dh.ThanhToan = true;
            }
            if(dh.TrangThai == "Chưa thanh toán")
            {
                dh.ThanhToan = false;
            }
            db.SaveChanges();
        }
    }
}
