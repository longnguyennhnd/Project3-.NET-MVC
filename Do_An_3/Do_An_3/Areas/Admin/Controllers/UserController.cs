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
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDAO();
        //        var encryptedMdPass = Encryptor.MD5Hash(user.Password);
        //        user.Password = encryptedMdPass;
        //        int id = dao.Insert(user);
        //        if (id > 0)
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Thêm user thành công");
        //    }
        //    return View("Index");
        //}
        //public ActionResult Edit(int id)
        //{
        //    var user = new UserDAO().ViewDetail(id);
        //    return View(user);
        //}
        //[HttpPost]
        //public ActionResult Edit(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDAO();
        //        if (!string.IsNullOrEmpty(user.Password))
        //        {
        //            var encryptedMdPass = Encryptor.MD5Hash(user.Password);
        //            user.Password = encryptedMdPass;
        //        }
                
        //        var result = dao.Update(user);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "User");
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Cập nhật user thành công");
        //    }
        //    return View("Index");
        //}
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult ViewDetail(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return Json(new
            {
                model = user,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveEdit(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            User us = serializer.Deserialize<User>(model);
            var dao = new UserDAO();
            //var encryptedMdPass = Encryptor.MD5Hash(us.Password);
            //us.Password = encryptedMdPass;
            var result = dao.Update(us);
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Addmd(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            User us = serializer.Deserialize<User>(model);
            var dao = new UserDAO();
            var encryptedMdPass = Encryptor.MD5Hash(us.Password);
            us.Password = encryptedMdPass;
            var result = dao.Insert(us);
            return Json(new
            {
                status = true
            });
        }
    }
}