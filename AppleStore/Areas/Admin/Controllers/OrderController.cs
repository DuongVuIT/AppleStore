using AppleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        AppleStoreEntities db = new AppleStoreEntities();
        public ActionResult Index()
        {
            var donhang = db.Don_Hang.ToList();
            return View(donhang);
        }
        public ActionResult Details(int id)
        {
            List<Chi_Tiet_Don_Hang> chitiet = db.Chi_Tiet_Don_Hang.Where(n => n.idDonHang == id).ToList();
            return View(chitiet.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var don = db.Don_Hang.Where(n => n.id == id).FirstOrDefault();
            return View(don);
        }
        [HttpPost]
        public ActionResult Edit(int id,Don_Hang don_Hang)
        {
            db.Entry(don_Hang).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}