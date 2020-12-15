using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Do_An_3.Common;
using PagedList;
using System.Web.Script.Serialization;

namespace Do_An_3.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new SanPhamDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SanPhamDAO().Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult ViewDetail(int? id)
        {
            var sp = new SanPhamDAO().ViewDetail(id);
            return Json(new
            {
                model = sp,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveEdit(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Sanpham sp = serializer.Deserialize<Sanpham>(model);
            var dao = new SanPhamDAO();
            var result = dao.Update(sp);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Addmd(string model, string AnhSP, string TenSP, float GiaBan, string TrangThai, string ThietKeBoi, int SoLuong, string KichThuoc, int MaLoaiSP, int MaNCC)
        {
            Sanpham s = new Sanpham();
            string[] tmp = AnhSP.Split('\\');
            s.AnhSP = tmp[tmp.Length - 1];
            s.TenSP = TenSP;
            s.GiaBan = GiaBan;
            s.TrangThai = TrangThai;
            s.ThietKeBoi = ThietKeBoi;
            s.SoLuong = SoLuong;
            s.KichThuoc = KichThuoc;
            s.MaLoaiSP = MaLoaiSP;
            s.MaNCC = MaNCC;
            var dao = new SanPhamDAO();
            var result = dao.Insert(s);
            return Json(new
            {
                status = true
            });
        }
    }
}