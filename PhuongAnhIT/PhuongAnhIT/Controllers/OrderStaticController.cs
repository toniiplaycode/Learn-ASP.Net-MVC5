using PhuongAnhIT.Models;
using System.Linq;
using System.Web.Mvc;

namespace PhuongAnhIT.Controllers
{
    public class OrderStaticController : Controller
    {
        // hiển thị ra danh sách các đơn hàng
        public ActionResult Index()
        {
            return View(DanhSachDonHangStatic.ListDonHang);
        }

        // form thêm mới đơn hàng
        public ActionResult ThemMoiDonHang()
        {
            return View(new DonHang());
        }

        // nhận các value từ form và Add vào ListDonHang
        [HttpPost]
        public ActionResult ThemMoiDonHang(DonHang model)
        {
            DanhSachDonHangStatic.ListDonHang.Add(model);
            return RedirectToAction("Index");
        }

        //form cập nhật đơn hàng theo id
        public ActionResult CapNhatDonHang(int idDonHang)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            return View(donHang);
        }

        //nhận value từ form cập nhật và cập nhập lại thuộc tính cho đơn hàng theo id
        [HttpPost]
        public ActionResult CapNhatDonHang(DonHang model)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == model.Id);
            donHang.NameCustomer = model.NameCustomer;
            donHang.PhoneNumber = model.PhoneNumber;
            donHang.Address = model.Address;
            donHang.OrderDate = model.OrderDate;
            return RedirectToAction("Index");
        }

        //xoá đơn hàng theo id
        public ActionResult XoaDonHang(int idDonHang)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            DanhSachDonHangStatic.ListDonHang.Remove(donHang);
            return RedirectToAction("Index");
        }

        // tạo trang chi tiết bằng tool Template: Detail, Model class: DonHang
        public ActionResult ChiTietDonHang(int idDonHang)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            return View(donHang);
        }

        // thêm chi tiết đơn hàng (thêm máy tính) cho đơn hàng theo id, Template: Create, Model class: MayTinh
        public ActionResult ThemChiTietDonHang(int idDonHang)
        {
            ViewBag.idDonHang = idDonHang;
            return View(new MayTinh());
        }

        // nhận các value từ form và Add vào MayTinhDatMua cho donHang theo id
        [HttpPost]
        // tham số idDonHang được truyền từ method Post
        public ActionResult ThemChiTietDonHang(MayTinh model, int idDonHang)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            donHang.MayTinhDatMua.Add(model);
            return RedirectToAction("ChiTietDonHang", new { idDonHang = idDonHang }); // chuyển trang kèm tham số
        }

        //form cập nhật chi tiết đơn hàng theo id và MaMay, 2 tham số đó được có trong thẻ a của bên View ChiTietDonHang
        public ActionResult CapNhatChiTietDonHang(int idDonHang, string maMay)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            var mayTinh = donHang.MayTinhDatMua.SingleOrDefault(m => m.MaMay == maMay);
            ViewBag.idDonHang = idDonHang;
            ViewBag.MaMay = maMay;
            return View(mayTinh);
        }

        //nhận value từ form cập nhật và cập nhập lại thuộc tính cho MayTinh theo MaMay 
        [HttpPost]
        public ActionResult CapNhatChiTietDonHang(MayTinh model, int idDonHang)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            var mayTinh = donHang.MayTinhDatMua.SingleOrDefault(m => m.MaMay == model.MaMay);
            mayTinh.DongMay = model.DongMay;
            mayTinh.GiaBan = model.GiaBan;
            mayTinh.HangSanXuat = model.HangSanXuat;
            mayTinh.NgaySanXuat = model.NgaySanXuat;
            return RedirectToAction("ChiTietDonHang", new { idDonHang = idDonHang }); // chuyển trang kèm tham số
        }

        //xoá chi tiết đơn hàng theo id và maMay
        public ActionResult XoaChiTietDonHang(int idDonHang, string maMay)
        {
            var donHang = DanhSachDonHangStatic.ListDonHang.SingleOrDefault(m => m.Id == idDonHang);
            var mayTinh = donHang.MayTinhDatMua.SingleOrDefault(m => m.MaMay == maMay);
            donHang.MayTinhDatMua.Remove(mayTinh);
            return RedirectToAction("ChiTietDonHang", new { idDonHang = idDonHang }); // chuyển trang kèm tham số
        }
    }
}

