using AppleStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        AppleStoreEntities db = new AppleStoreEntities();
        // GET: Admin/Products
        public ActionResult Index()
        {
            var sp = db.San_Pham.ToList();
            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(sp);
            }
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.idloaiSP = new SelectList(db.Loai_San_Pham, "id", "tenloaiSP"); 
            return View();
        }
        [HttpPost]
        public ActionResult Create(San_Pham sp, HttpPostedFileBase ImageUpload)
        {
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                string extension = Path.GetExtension(ImageUpload.FileName);
                fileName = fileName + extension;
                sp.hinh = fileName;
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
            }
            db.San_Pham.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var sp = db.San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(sp);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            var sp = db.San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(sp);
        }
        [HttpPost]

        public ActionResult Delete(San_Pham ssp)
        {
            var sp = db.San_Pham.Where(n => n.id == ssp.id).FirstOrDefault();
            db.San_Pham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sp = db.San_Pham.Where(n=>n.id==id).FirstOrDefault();
            ViewBag.idloaiSP = new SelectList(db.Loai_San_Pham, "id", "tenloaiSP", sp.idloaiSP);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(int id, San_Pham sp, HttpPostedFileBase ImageUpload)
        {
            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                string extension = Path.GetExtension(ImageUpload.FileName);
                fileName = fileName + extension;
                sp.hinh = fileName;
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images"), fileName));
            }

            db.Entry(sp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}