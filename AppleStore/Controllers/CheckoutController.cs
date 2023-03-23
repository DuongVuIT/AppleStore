using AppleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppleStore.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        AppleStoreEntities db = new AppleStoreEntities();
        [HttpGet]
        public ActionResult Checkout()
        {
            return View((List<Cart>)Session["cart"]);
        }

        [HttpPost]
        public ActionResult Checkout(string ten, string SDT, string email, string diachi, string tieude)
        {
           
            List<Cart> lst = (List<Cart>)Session["cart"];
            Don_Hang donhang = new Don_Hang();
            donhang.ngaytao = DateTime.UtcNow.AddHours(7);

            donhang.ten = ten;
            donhang.email = email;
            donhang.SDT = SDT;
            donhang.tieude = tieude;
            donhang.diachi = diachi;
            donhang.tongtien = lst.Sum(n => n.Quantity * n.San_Pham.gia);

            Session["tongtien"] = donhang.tongtien;
            Session["tendat"] = donhang.ten;
            Session["SDTdat"] = donhang.SDT;
            Session["tieude"] = donhang.tieude;
            Session["diachidat"] = donhang.diachi;

            Session["ngaydat"] = donhang.ngaytao;

            db.Don_Hang.Add(donhang);
            db.SaveChanges();


            int chitietID = donhang.id;
            List<Chi_Tiet_Don_Hang> lstchitiet = new List<Chi_Tiet_Don_Hang>();


            foreach (var item in lst)
            {
                Chi_Tiet_Don_Hang chitiet = new Chi_Tiet_Don_Hang();
                chitiet.idDonHang = chitietID;
                chitiet.tenSP = item.San_Pham.tenSP;
                chitiet.idSP = item.San_Pham.id;
                chitiet.soluong = item.Quantity;
                chitiet.gia = item.San_Pham.gia;
                chitiet.tonggia = item.Quantity * item.San_Pham.gia;

                db.Chi_Tiet_Don_Hang.Add(chitiet);
                db.SaveChanges();


            }
            return RedirectToAction("CheckoutSuccess");
        }
        public ActionResult CheckoutSuccess()
        {
            return View();
        }
    }
}