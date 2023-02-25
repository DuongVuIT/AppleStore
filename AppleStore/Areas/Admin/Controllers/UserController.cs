using AppleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        AppleStoreEntities db = new AppleStoreEntities();
        public ActionResult Index()
        {
            var user = db.Nguoi_Dung.ToList();
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(user);
            }
            
        }
        public ActionResult Delete(int id)
        {

            var user = db.Nguoi_Dung.Where(n => n.id == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]

        public ActionResult Delete(Nguoi_Dung userr)
        {
            var user = db.Nguoi_Dung.Where(n => n.id == userr.id).FirstOrDefault();
            db.Nguoi_Dung.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var user = db.Nguoi_Dung.Where(n => n.id == id).FirstOrDefault();
            return View(user);
        }
    }
}