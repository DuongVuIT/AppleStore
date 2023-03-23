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
    }
}