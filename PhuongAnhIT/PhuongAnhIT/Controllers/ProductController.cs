using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhuongAnhIT.Models; // import các class có trong Models

namespace PhuongAnhIT.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            // truyền dữ liệu từ Controller -> Views cách tường minh
            /* MayTinh dsMayTinh = new MayTinh();
            return View(dsMayTinh.KhoiTa5May()); */
             
            // truyền dữ liệu từ Controller -> Views cách ngắn gọn
            return View(new MayTinh().KhoiTao5May());            
        }
        
        // Hiển thị 2 máy có giá thấp nhất
        public ActionResult HaiMayGiaThapNhat()
        {
            return View(new MayTinh().KhoiTao5May().OrderBy(m => m.GiaBan).Take(2).ToList());
        }

        // Hiển thị sắp xếp từ giá cao đến thấp
        public ActionResult SapXepGiamDan()
        {
            return View(new MayTinh().KhoiTao5May().OrderByDescending(m => m.GiaBan).ToList());
        }

        // Hiển thị các máy thuộc hãng Asus
        public ActionResult HangAsus()
        {
            return View(new MayTinh().KhoiTao5May().Where(m => m.HangSanXuat == "Asus").ToList());
        } 
    } 
}