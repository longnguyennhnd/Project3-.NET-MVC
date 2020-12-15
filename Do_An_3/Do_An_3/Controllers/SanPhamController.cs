using Do_An_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Do_An_3.Businiess;
using PagedList;


namespace Do_An_3.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult XemChiTiet(int? maSP)
        {
            SanPhamDAO dao = new SanPhamDAO();
            XemSanPhamBus b = new XemSanPhamBus();
            //ViewBag.ChiTietsp = dao.Lay1SP(maSP).ChiTietSP;
            return View(b.Lay1SP(maSP));
        }
        public ActionResult SanPham(int? Maphong, int? Maloaisp, int? page)
        {
            SanPhamDAO dao = new SanPhamDAO();
            if (Maphong == null || Maloaisp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            if (dao.LaySPTheoMaLoai(Maphong, Maloaisp).Count() == 0)
            {
                return HttpNotFound();
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.Maloaisp = Maloaisp;
            ViewBag.Maphong = Maphong;
            ViewBag.ListSP = dao.LaySPTheoMaLoai(Maphong, Maloaisp);
            return View(dao.LaySPTheoMaLoai(Maphong, Maloaisp).OrderBy(n=>n.MaSP).ToPagedList(pageNumber,pageSize));
        }
    }
}