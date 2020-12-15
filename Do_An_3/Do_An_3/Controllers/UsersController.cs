using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
using Do_An_3.Models;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Do_An_3.Common;

namespace Do_An_3.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var user = dao.GetByID(model.UserName);
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var acountSession = new AccountLogin();
                    acountSession.UserName = user.UserName;
                    acountSession.AccountID = user.IDAcount;
                    Session.Add(CommonConstants.ACCOUNT_SESSION, acountSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
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
            return View(model);
        }
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            var dao = new AccountDAO();
            if (this.IsCaptchaValid("Captcha is not valid"))
            {

                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else if (dao.CheckUserEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new ClientAccount();
                    user.Name = model.Name;
                    user.UserName = model.UserName;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Chào mừng bạn đến với UMA";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }
            else
                ViewBag.ThongBaoCaptcha = "Mã captcha không đúng!";
            return View(model);
        }
    }
}