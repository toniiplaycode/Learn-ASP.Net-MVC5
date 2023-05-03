using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhuongAnhIT.Models;

namespace PhuongAnhIT.Controllers
{
    public class ProductStaticController : Controller
    {
        // GET: ProductStatic
        public ActionResult Index()
        {
            // dùng static nên không dùng New để tạo đối tượng
            return View(DanhSachMayTinhStatic.ListMayTinh);
        }

        //#1 Dùng form thuần, method bên form là post
        public ActionResult ThemMoiMayTinh()
        {
            return View();
        }
        //#1 Dùng form thuần, method bên form là post
        [HttpPost]
        public ActionResult LuuThemMoiMayTinh(string maMay, string anh, string dongMay, string hangSanXuat, double giaBan, DateTime ngaySanXuat)
        {
            DanhSachMayTinhStatic.ListMayTinh.Add(new MayTinh() 
            { 
                MaMay = maMay,
                Anh = anh, 
                DongMay = dongMay, 
                HangSanXuat = hangSanXuat, 
                GiaBan = giaBan,
                NgaySanXuat = ngaySanXuat
            });
            // sau khi thêm mới sau thì chuyển về Views Index 
            return RedirectToAction("Index");
        }

        //#2 Dùng tool tạo View có form sẵn(chọn template Create, Model class MayTinh), tham số return View là Models, method bên form là postl, 2 action trùng tên với nhau
        public ActionResult ThemMoiMayTinh2()
        {
            return View(new MayTinh());
        }
        //#2 Dùng tool tạo View có form sẵn(chọn template Create, Model class MayTinh), method bên form là post
        // tham số model có kiểu dữ liệu đối tượng trong action LuuThemMoiMayTinh2 sẽ nhận được dữ liệu từ form bên Views
        [HttpPost]
        public ActionResult ThemMoiMayTinh2(MayTinh model)
        {
            if(ModelState.IsValid == true)
            {
                // cách 1 Add tường minh
                /* DanhSachMayTinhStatic.ListMayTinh.Add(new MayTinh()
                {
                    MaMay = model.MaMay,
                    Anh = model.Anh,
                    DongMay = model.DongMay,
                    HangSanXuat = model.HangSanXuat,
                    GiaBan = model.GiaBan,
                    NgaySanXuat = model.NgaySanXuat
                }); */

                // cách 2 Add ngắn ngọn
                DanhSachMayTinhStatic.ListMayTinh.Add(model);

                // sau khi thêm mới sau thì chuyển về Views 
                return RedirectToAction("Index");
            }
            else
            {
                // kèm thông báo lỗi
                ModelState.AddModelError("", "Bạn chưa nhập đủ dữ liệu !");
                return View(model); // khi lỗi thì sẽ return lại chính Views ThemMoiMayTinh2 không báo ra lỗi và điền lại value cho các ô input
            }
        }

    } 
}    