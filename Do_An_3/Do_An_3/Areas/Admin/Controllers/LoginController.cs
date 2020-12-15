using Do_An_3.Areas.Admin.Models;
using Do_An_3.Common;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace Do_An_3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            var dao = new UserDAO();
            if (ModelState.IsValid)
            {
                var user = dao.GetByID(model.userName);
                var Dao = new UserDAO();
                var result = Dao.Login(model.userName, Encryptor.MD5Hash(model.passWord));
                if (result ==1)
                {
                    
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.MaUser;
                    Session.Add(CommonConstants.USER_SESSION,userSession);
                    return RedirectToAction("Index", "HomeAdmin","Admin");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}