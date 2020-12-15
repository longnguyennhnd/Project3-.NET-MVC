using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Do_An_3.Areas.Admin.Models;

namespace Do_An_3.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            OrderDAO dao = new OrderDAO();
            var model = dao.ListAllPaging(page = 1, pageSize = 10);
            return View(model);
        }
        public ActionResult ChuaThanhToan()
        {
            OrderDAO dao = new OrderDAO();
            var model = dao.LayDonHangChuaThanhToan();
            return View(model);
        }
        public ActionResult DaThanhToan()
        {
            OrderDAO dao = new OrderDAO();
            var model = dao.LayDonHangDaThanhToan();
            return View(model);
        }
        public ActionResult LayCTDH(int? maDH)
        {
            var ct = new CT_DonHangDAO().LayBanGhi(maDH);
            List<OrderDetailViewModel> lst = new List<OrderDetailViewModel>();
            ct.ForEach(x =>
            {
                var ctdh = new OrderDetailViewModel();
                ctdh.Ten = x.Sanpham.TenSP;
                ctdh.Anh = x.Sanpham.AnhSP;
                ctdh.SoLuong = x.SoLuong;
                ctdh.DonGia = x.DonGia;
                ctdh.TongTien = x.TongTien;
                lst.Add(ctdh);
            });
            return Json(new
            {
                data = lst,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LuuDH(int? id, string TrangThai)
        {
            OrderDAO dao = new OrderDAO();
            dao.LuuDH(id,TrangThai);
            return Json(new {
                status = true
            },JsonRequestBehavior.AllowGet);
        }
    }
}