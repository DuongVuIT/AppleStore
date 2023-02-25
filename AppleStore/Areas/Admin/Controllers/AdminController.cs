using AppleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        AppleStoreEntities db = new AppleStoreEntities();
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string taikhoan, string matkhau)
        {
            if (ModelState.IsValid)
            {

                var data = db.Nguoi_Dung.Where(n => n.taikhoan.Equals(taikhoan) && n.matkhau.Equals(matkhau));
                if (data.Count() > 0)
                {
                    Session["ten"] = data.FirstOrDefault().ten;
                    Session["quyen"] = data.FirstOrDefault().quyen;
                    Session["id"] = data.FirstOrDefault().id;
                    if (Session["quyen"] == null)
                    {
                        return Redirect("~");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}