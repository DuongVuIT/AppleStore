
using AppleStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        
        AppleStoreEntities db = new AppleStoreEntities();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var lsp = db.Loai_San_Pham.ToList();

            if (Session["id"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(lsp);
            }
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Loai_San_Pham lsp)
        {
            db.Loai_San_Pham.Add(lsp);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var lsp = db.Loai_San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(lsp);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var lsp = db.Loai_San_Pham.Where(n => n.id == id).FirstOrDefault();
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Delete (Loai_San_Pham loai_sp)
        {
            var lsp = db.Loai_San_Pham.Where(n=>n.id == loai_sp.id).FirstOrDefault();
            db.Loai_San_Pham.Remove(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            var lsp = db.Loai_San_Pham.Where (n => n.id == id).FirstOrDefault();
            return View(lsp);
        }
        [HttpPost]
        public ActionResult Edit (int id, Loai_San_Pham lsp)
        {
            db.Entry(lsp).State = (System.Data.Entity.EntityState)EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    
    }
}
