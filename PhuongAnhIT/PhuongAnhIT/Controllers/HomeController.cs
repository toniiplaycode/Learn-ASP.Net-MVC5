using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhuongAnhIT.Models; // import các class có trong Models

namespace PhuongAnhIT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // 1. truyền bằng ViewBag
            //ViewBag.A = 10;
            /* MathHelp TinhTong = new MathHelp();
            ViewBag.TinhTong = TinhTong.TinhTong(10, 20); */
            //-> viết kiểu trên hơi dài dòng
            //ViewBag.TinhTong = new MathHelp().TinhTong(10, 20);

            // 2. truyền qua tham số của View()
            // - truyền 1 số nguyên 
            //return View(10);
            // - truyền 1 class
            List<clsSinhVien> DsSinhVien = new List<clsSinhVien>();

            var sv1 = new clsSinhVien();
            sv1.ID = 1;
            sv1.MaSo = "A2110425";
            sv1.HoVaTen = "Le Thanh Toan";
            sv1.Lop = "DH21TIN06";
            DsSinhVien.Add(sv1);

            var sv2 = new clsSinhVien();
            sv2.ID = 2;
            sv2.MaSo = "A1234567";
            sv2.HoVaTen = "Phan Thanh Tri";
            sv2.Lop = "DH21TIN06";
            DsSinhVien.Add(sv2);

            return View(DsSinhVien);
        }
    }
}