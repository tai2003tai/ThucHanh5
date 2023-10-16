using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1 ();
        //đăng  nhập 
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(User user)
        {
            var DangNhapForm = user.Email;
            var DangKyForm = user.MatKhau;
            var usercheck = db.Users.SingleOrDefault(x =>x.Email.Equals(DangNhapForm) && x.MatKhau.Equals(DangKyForm));
            if(usercheck != null)
            {
                Session["User"]=usercheck;
                return RedirectToAction("Index","Home");
            }    
            else
            {
                ViewBag.Email = "Đăng nhập thất bại , Vui lòng kiểm tra lại Email hoặc Mật Khẩu";
                return View("DangNhap");
            }
            
           
        }
        //đăng  ký 
        public ActionResult DangKy()
        {
            return View();
        }
        //Get/HTTP POST/HOME
        [HttpPost]
        public ActionResult DangKy(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("DangNhap");
        }
        //đăng  Xuất
       
        //HTTP POST/HOME/DangXuat
       
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            return RedirectToAction("index","Home");
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}