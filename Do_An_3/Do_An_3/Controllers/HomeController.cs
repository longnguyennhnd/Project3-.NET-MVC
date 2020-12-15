using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_3.Models;
using Model.EF;
using Model.DAO;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using Do_An_3.Common;

namespace Do_An_3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            SanPhamDAO db = new SanPhamDAO();
            var lstSanPham = db.LaySPHome();
            return View(lstSanPham);
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            SanPhamDAO db = new SanPhamDAO();
            var ds = db.LaySP();
            return PartialView(ds);
        }
        public ActionResult TopMenu()
        {
            return PartialView();
        }
        public ActionResult Muahang(int id)
        {
            SanPhamDAO db = new SanPhamDAO();
            var ds = db.LaySP();
            List<GioHang> gh = null;
            if (Session["GioHang"] == null)
            {
                GioHang a = new GioHang();
                Sanpham sp = db.LaySP().SingleOrDefault(s => s.MaSP == id);
                if (sp != null)
                {
                    a.ID = sp.MaSP;
                    a.Name = sp.TenSP;
                    a.SL = 1;
                    a.DonGia = (float)sp.GiaBan;
                    a.Image = sp.AnhSP;
                    gh = new List<GioHang>();
                    gh.Add(a);
                    Session["GioHang"] = gh;
                }
            }
            else
            {
                gh = (List<GioHang>)Session["GioHang"];
                var test = gh.Find(s => s.ID == id);
                if (test == null)
                {
                    GioHang a = new GioHang();
                    var sp = db.LaySP().Where(s => s.MaSP == id).Single();
                    a.ID = sp.MaSP;
                    a.Name = sp.TenSP;
                    a.SL = 1;
                    a.DonGia = (float)sp.GiaBan;
                    a.Image = sp.AnhSP;
                    gh.Add(a);
                }
                else
                {
                    test.SL = int.Parse(test.SL.ToString()) + 1;

                }
                Session["GioHang"] = gh;
            }
            float tongtien = 0;
            int soluong = 0;
            if (gh != null)
            {

                foreach (GioHang sp in gh)
                {
                    tongtien += sp.SL * sp.DonGia;
                }
                soluong = gh.Count;
            }
            return Json(new { GioHang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteProductFromCart(int ID)
        {
            List<GioHang> cart = (List<GioHang>)Session["GioHang"];
            int soluong = 0;
            if (cart == null)
            {
                return new JsonResult() { Data = new { Status = "Lỗi" } };
            }
            else
            {
                cart.RemoveAt(cart.FindIndex(item => item.ID == ID));
                soluong = cart.Count;
                return new JsonResult() { Data = new { Status = "Thành công" } };
            }
        }
        public ActionResult View_Cart()
        {
            List<GioHang> gh = null;
            float tongtien = 0;
            ViewBag.tongtien = "";
            int count = 0;
            if (Session["GioHang"] != null)
            {
                gh = (List<GioHang>)Session["GioHang"];
                foreach (GioHang a in gh)
                {
                    tongtien += a.SL * a.DonGia;
                }
                count = gh.Count;
            }
            ViewBag.count = count;
            ViewBag.tongtien = tongtien;
            return View(gh);
        }
        [HttpGet]
        public ActionResult Checkout()
        {
            List<GioHang> gh = null;
            float tongtien = 0;
            ViewBag.tongtien = "";
            int count = 0;
            if (Session["GioHang"] != null)
            {
                gh = (List<GioHang>)Session["GioHang"];
                foreach (GioHang a in gh)
                {
                    tongtien += a.SL * a.DonGia;
                }
                count = gh.Count;
            }
            ViewBag.count = count;
            ViewBag.tongtien = tongtien;
            return View(gh);
        }
        QuanLyBanNoiThatEntities db = new QuanLyBanNoiThatEntities();
        [HttpPost]
        public ActionResult Checkout(string name, string address, string phonenum, string email)
        {
            int id = 1;
            try
            {
                var dt = db.DonDatHang.Select(s => new { s.MaDDH }).OrderByDescending(s => s.MaDDH).FirstOrDefault();
                id = dt.MaDDH + 1;
            }
            catch (Exception)
            {

            }
            DonDatHang thongtin = new DonDatHang();
            thongtin.Name = name;
            thongtin.PhoneNum = phonenum;
            thongtin.Email = email;
            thongtin.DiaChiGiaoHang = address;
            thongtin.NgayDat = DateTime.Now;
            thongtin.TrangThai = "Đã xác nhận";
            float tongtien = 0;
            thongtin.ThanhToan = false;
            if (Session["GioHang"] != null)
            {
                var gh = (List<GioHang>)Session["GioHang"];
                foreach (GioHang a in gh)
                {
                    tongtien += a.SL * a.DonGia;
                }
            }
            thongtin.MaDDH = id;
            thongtin.TongTien = tongtien;
            db.DonDatHang.Add(thongtin);
            db.SaveChanges();
            if (Session["GioHang"] != null)
            {
                var gh = (List<GioHang>)Session["GioHang"];
                foreach (GioHang a in gh)
                {
                    CT_DonDatHang ct = new CT_DonDatHang();
                    ct.MaSP = a.ID;
                    ct.MaDDH = id;
                    ct.DonGia = a.DonGia;
                    ct.SoLuong = a.SL;
                    ct.TongTien = a.SL * a.DonGia;
                    foreach(var i in db.Sanpham)
                    {
                        if(i.MaSP == ct.MaSP)
                        {
                            i.SoLuong = i.SoLuong - a.SL;
                        }
                    }
                    db.CT_DonDatHang.Add(ct);
                    db.SaveChanges();
                }
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendMailToUser(string mail)
        {
            MailHelper m = new MailHelper();
            Random rd = new Random();
            var activationcode = rd.Next(1001, 9999).ToString();
            if (mail != "")
            {
                bool result = true;
                ViewBag.code = activationcode;
                result = m.SendMail(mail, "UMA Siêu Thị Nội Thất", "<p>Mã xác nhận của bạn là: " + activationcode + "<br />Nhập mã ngay, trải nghiệm muôn vàn điều hay! </br > Chúc bạn có những phút giây thư giãn & mua sắm tuyệt vời! </br > BAYA cảm ơn & hẹn gặp lại bạn.</p>");
            }
            else
                ViewBag.thongbaoemail = "Bạn phải điền email";
            return Json(new { success = true, code = activationcode }, JsonRequestBehavior.AllowGet);
        }
    }
}