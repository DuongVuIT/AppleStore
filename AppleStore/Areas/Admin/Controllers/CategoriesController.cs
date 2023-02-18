
using AppleStore.Models;
using System;
using System.Collections.Generic;
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

            return View(lsp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Loai_San_Pham lsp)
        {
            db.Loai_San_Pham.Add(lsp);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}