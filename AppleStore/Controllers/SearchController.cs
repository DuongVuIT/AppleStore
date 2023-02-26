using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AppleStore.Models;
using PagedList;

namespace AppleStore.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        AppleStoreEntities db = new AppleStoreEntities();
        [HttpPost]
        public ActionResult Search(FormCollection f, int page = 1, int Pagesize = 6)
        {
            string tukhoa = f["txtTimkiem"].ToString();
            ViewBag.TuKhoa = tukhoa;
            List<San_Pham> lsttimkiem = db.San_Pham.Where(n => n.tenSP.Contains(tukhoa)).ToList();
            if (lsttimkiem.Count == 0)
            {
                ViewBag.ThongBaoo = "Không tìm thấy sản phẩm nào";
                return View(db.San_Pham.OrderBy(n => n.tenSP).ToPagedList(page, Pagesize));
            }
            ViewBag.ThongBaoo = "Đã Tìm Thấy " + lsttimkiem.Count + " Kết quả";
            return View(lsttimkiem.OrderBy(n => n.tenSP).ToPagedList(page, Pagesize));
        }
        [HttpGet]
        public ActionResult Search(String tukhoa, int page = 1, int Pagesize = 6)
        {
            ViewBag.TuKhoa = tukhoa;
            List<San_Pham> lsttimkiem = db.San_Pham.Where(n => n.tenSP.Contains(tukhoa)).ToList();
            if (lsttimkiem.Count == 0)
            {
                ViewBag.ThongBaoo = "Không tìm thấy sản phẩm nào";
                return View(db.San_Pham.OrderBy(n => n.tenSP).ToPagedList(page, Pagesize));
            }
            ViewBag.ThongBaoo = "Đã Tìm Thấy " + lsttimkiem.Count + " Kết quả";
            return View(lsttimkiem.OrderBy(n => n.tenSP).ToPagedList(page, Pagesize));
        }
    }
}
