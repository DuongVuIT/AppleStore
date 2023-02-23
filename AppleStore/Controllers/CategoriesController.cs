using AppleStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class CategoriesController : Controller
    {
        AppleStoreEntities db = new AppleStoreEntities();
        public ActionResult Categories()
        {
            return PartialView(db.Loai_San_Pham.ToList());
        }
        public ViewResult ProductsCategories(int id, int page = 1, int Pagesize = 6)
        {

            List<San_Pham> sanpham = db.San_Pham.Where(n => n.idloaiSP == id).ToList();

            return View(sanpham.ToList().ToPagedList(page, Pagesize));
        }
    }
}