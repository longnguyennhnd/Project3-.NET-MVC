using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace Do_An_3.Controllers
{
    public class PhongController : Controller
    {
        // GET: Phong
        public ActionResult Index(int? Maphong)
        {
            PhongDAO dao = new PhongDAO();
            if (Maphong == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var lstsp = db.Sanpham.Where(n => n.MaLoaiSP == Maloaisp);

            if (dao.LayLSPTheoMaPhong(Maphong).Count() == 0)
            {
                return HttpNotFound();
            }
            ViewBag.ListSP = dao.LayLSPTheoMaPhong(Maphong);
            return View(dao.LayLSPTheoMaPhong(Maphong));
        }
        
    }
}