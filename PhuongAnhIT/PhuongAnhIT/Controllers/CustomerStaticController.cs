using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhuongAnhIT.Models; // import các class có trong Models

namespace PhuongAnhIT.Controllers
{
    public class CustomerStaticController : Controller
    {
        // hiển thị ra danh sách các khách hàng
        public ActionResult Index()
        {
            return View(DanhSachKhachHangStatic.ListKhachHang);
        }

        // form thêm mới khách hàng
        public ActionResult ThemMoiKhachHang()
        {
            return View(new KhachHang());
        }

        // nhận các value từ form và Add vào ListKhachHang
        [HttpPost]
        public ActionResult ThemMoiKhachHang(KhachHang model, HttpPostedFileBase fileAnh)
        {

            if (fileAnh.ContentLength > 0) // check độ lớn của file
            {
                // lưu file
                string rootFolder = Server.MapPath("/Asset/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                // lưu thuộc tính Avatar
                model.Avatar = "/Asset/" + fileAnh.FileName;
            }

            if (model.Id == 0 || model.Name == null || model.Number == 0 || model.Address == null || model.Email == null || model.Sex == null)
            {   
                ModelState.AddModelError("", "Phải điền đủ thông tin!");
                return View(model);
            }
            else
            {
                DanhSachKhachHangStatic.ListKhachHang.Add(model);
                return RedirectToAction("index");
            }
        }

        //form cập nhật khách hàng theo id
        //khi trang index nhấn vào link để sửa "<a href="~/CustomerStatic/CapNhatKhachHang?idKhachHang=@item.Id">Sửa</a>" thì nó sẽ vào Action CapNhatKhachHang kèm tham số là id được truyền trên thanh địa chỉ 
        public ActionResult CapNhatKhachHang(int idKhachHang)
        {
            // cập nhật khách hàng theo id, hàm SingleOrDefault tìm kiếm khách hàng theo id
            var khachHang = DanhSachKhachHangStatic.ListKhachHang.SingleOrDefault(m=> m.Id == idKhachHang);
            // truyền thông tin khách hàng cần sửa sang bên Views
            return View(khachHang);
        }

        //nhận value từ form cập nhật và cập nhập lại thuộc tính cho khách hàng theo id
        [HttpPost]
        public ActionResult CapNhatKhachHang(KhachHang model)
        { 
            // cập nhật các thuộc tính của khách hàng theo id, hàm SingleOrDefault tìm kiếm khách hàng theo id
            var khachHang = DanhSachKhachHangStatic.ListKhachHang.SingleOrDefault(m => m.Id == model.Id);
            // cập nhật thuộc tính mới cho khách hàng cần sửa
            khachHang.Name = model.Name;
            khachHang.Number = model.Number;
            khachHang.Address = model.Address;
            khachHang.Email = model.Email;
            khachHang.Sex = model.Sex;  
            khachHang.Avatar = model.Avatar;

            return RedirectToAction("Index");
        }

        //xoá khách hàng theo id, cơ chế truyền tham số id giống Action CapNhatKhachHang
        public ActionResult XoaKhachHang(int idKhachHang)
        {
            // xoá khách hàng theo id, hàm SingleOrDefault tìm kiếm theo khách hàng theo id
            var khachHang = DanhSachKhachHangStatic.ListKhachHang.SingleOrDefault(m => m.Id == idKhachHang);
            // hàm remove để xoá khách hàng
            DanhSachKhachHangStatic.ListKhachHang.Remove(khachHang);

            return RedirectToAction("Index");
        }
    }
}
