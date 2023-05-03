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
        public ActionResult Index()
        {
            return View(DanhSachKhachHangStatic.ListKhachHang);
        }

        public ActionResult ThemMoiKhachHang()
        {
            return View(new KhachHang());
        }

        [HttpPost]
        public ActionResult ThemMoiKhachHang(KhachHang model, HttpPostedFileBase fileAnh)
        {

            if (fileAnh.ContentLength > 0) // check độ lớn của file, nếu có upfile thì sẽ lớn hơn 0
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
    }
}