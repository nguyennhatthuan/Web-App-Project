using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCinema.Models.Cinema;
using WebCinema.Areas.Admin.Models;

namespace WebCinema.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            var UserName = col["Username"];
            var Password = col["Password"];
            StaffDAO staffDAO = new StaffDAO();
            Staff user = staffDAO.Login(UserName, Password);
            if (String.IsNullOrEmpty(UserName))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(Password))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                if (user != null)
                {
                    Session["Account"] = user;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    //Thông báo
                    ViewBag.ThongBaoLoi = "Đăng nhập thất bại";
                }
            }
            return View();       
        }
    }
}