using AppleStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class HomeController : Controller
    {
        AppleStoreEntities db = new AppleStoreEntities();

        public ActionResult Index(int page = 1, int pagesize = 6)
        {
            
            return View(db.San_Pham.ToList().ToPagedList(page,pagesize));
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
        public ActionResult DetailsPro(int id)
        {
            San_Pham pro = db.San_Pham.SingleOrDefault(n => n.id == id);
            return View(pro);
        }
    }
}