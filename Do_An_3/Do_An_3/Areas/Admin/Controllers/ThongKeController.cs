using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace Do_An_3.Areas.Admin.Controllers
{
    
    public class ThongKeController : BaseController
    {

        // GET: Admin/ThongKe
        QuanLyBanNoiThatEntities db = new QuanLyBanNoiThatEntities();
        public ActionResult Index()
        {
            ViewBag.SoNguoiTruyCap = HttpContext.Application["SoNguoiTruyCap"].ToString();
            ViewBag.ThongKeDoanhThu = ThongKeDoanhThu();
            ViewBag.ThongKeDDH = ThongKeDonHang();
            ViewBag.ThongKeKH = ThongKeKhachHang();
            ViewBag.ThongKeDoanhThuThang = ThongKeDoanhThuTheoThang(12,2019);
            ViewBag.TongSLBan = ThongKeSLBan();
            ViewBag.TongSLBanTheoThang = ThongKeSLBanTheoThang(12,2019);
            ViewBag.TongHDXThang = ThongKeHDXThang(12, 2019);
            return View();
        }
        public int ThongKeDonHang()
        {
            int ddh = db.DonDatHang.Count();
            return ddh;
        }
        public decimal ThongKeSLBanTheoThang(int Thang, int Nam)
        {
            var lstSLBan = db.DonDatHang.Where(n => n.NgayDat.Value.Month == Thang && n.NgayDat.Value.Year == Nam);
            decimal TongSLBan = 0;
            foreach (var item in lstSLBan)
            {
                TongSLBan += decimal.Parse(item.CT_DonDatHang.Sum(n => n.SoLuong).Value.ToString());
            }
            return TongSLBan;
        }
        public decimal ThongKeHDXThang(int Thang, int Nam)
        {
            var lstHDX = db.DonDatHang.Where(n => n.NgayDat.Value.Month == Thang && n.NgayDat.Value.Year == Nam);
            decimal TongHDX = 0;
            foreach (var item in lstHDX)
            {
                TongHDX += lstHDX.Count();
            }
            return TongHDX;
        }
        public decimal ThongKeSLBan()
        {
            decimal TongSLBan = int.Parse(db.CT_DonDatHang.Sum(n => n.SoLuong).ToString());
            return TongSLBan;
        }
        public int ThongKeKhachHang()
        {
            int slKH = db.ClientAccount.Count();
            return slKH;
        }
        public decimal ThongKeDoanhThu()
        {
            var lstTongDoanhthu = db.DonDatHang.Where(n=> n.ThanhToan == true);
            decimal TongDoanhThu = 0;
            foreach (var item in lstTongDoanhthu)
            {
                TongDoanhThu += decimal.Parse(item.CT_DonDatHang.Sum(n => n.SoLuong * n.DonGia).Value.ToString());
            }
            return TongDoanhThu;
        }
        public decimal ThongKeDoanhThuTheoThang(int Thang, int Nam)
        {
            var lstDDH = db.DonDatHang.Where(n => n.NgayDat.Value.Month == Thang && n.NgayDat.Value.Year == Nam && n.ThanhToan == true);
            decimal TongTien = 0;
            foreach(var item in lstDDH)
            {
                TongTien += decimal.Parse(item.CT_DonDatHang.Sum(n => n.SoLuong * n.DonGia).Value.ToString());
            }
            return TongTien;
        }
    }
}