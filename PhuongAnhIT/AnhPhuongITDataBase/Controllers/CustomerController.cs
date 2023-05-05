using AnhPhuongITDataBase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AnhPhuongITDataBase.Controllers
{
    public class CustomerController : Controller
    {
        // kết nối DB và hiển thị ra danh sách khách hàng
        public ActionResult Index()
        {
            //1. lấy danh sách dữ liệu trong bảng
            PhuongAnhITEntities db = new PhuongAnhITEntities(); // khởi tạo 1 đối tượng db từ lớp PhuongAnhITEntities 
            List<KhachHang> danhSachKhachHang = db.KhachHangs.ToList(); // tạo 1 List danhSachKhachHang để truy xuất từ CSDL KhachHang

            return View(danhSachKhachHang);
        }

        // kết nối DB và tạo form thêm mới khách hàng 
        public ActionResult AddCustomer()
        {
            return View();
        }

        // kết nối DB và nhận value từ form sau đó thêm mới bản ghi vào CSDL
        [HttpPost]
        public ActionResult AddCustomer(KhachHang model)
        {
            // 2. thêm mới bản ghi
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            db.KhachHangs.Add(model);
            db.SaveChanges(); // lưu lại thay đổi (thêm, sửa, xoá đều phải SaveChanges());

            return RedirectToAction("Index");
        }

        // kết nối DB và tạo from sửa khách hàng theo id
        public ActionResult EditCustomer(int id)
        {
            // 3. Tìm đối tượng theo id
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            // var model = db.KhachHangs.SingleOrDefault(m => m.Id == id); // cách hay dùng bên Static
            var model = db.KhachHangs.Find(id); // cách dùng mới và gọn hơn

            return View(model);
        }

        // kết nối DB và nhận value từ form sửa sau đó sửa bản ghi theo id
        [HttpPost]
        public ActionResult EditCustomer(KhachHang model)
        {
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            var updateModel = db.KhachHangs.Find(model.Id); // tìm đối tượng theo id
            // gán giá trị mới cho updateModel
            updateModel.TenKhachHang = model.TenKhachHang;
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.DiaChi = model.DiaChi;
            db.SaveChanges(); // lưu lại thay đổi

            return RedirectToAction("Index");
        }

        // kết nối DB và khách hàng theo id
        public ActionResult DeleteCustomer(int id)
        {
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            var deleteModel = db.KhachHangs.Find(id); // tìm đối tượng theo id
            db.KhachHangs.Remove(deleteModel); // lệnh xoá đối tượng
            db.SaveChanges(); // lưu lại thay đổi

            return RedirectToAction("Index");
        }
    }
}
