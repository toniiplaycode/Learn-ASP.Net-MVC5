using AnhPhuongITDataBase.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AnhPhuongITDataBase.Controllers
{
    public class CustomerController : Controller
    {
        // kết nối DB và hiển thị ra danh sách khách hàng, ? là cho phép null
        public ActionResult Index(int? idLoaiKH)
        {
            //1. lấy danh sách dữ liệu trong bảng
            PhuongAnhITEntities db = new PhuongAnhITEntities(); // khởi tạo 1 đối tượng db từ lớp PhuongAnhITEntities 
            List<KhachHang> danhSachKhachHang = db.KhachHangs.Where(m => m.IdLoaiKhachHang == idLoaiKH || idLoaiKH == null).ToList(); // tạo 1 List danhSachKhachHang để truy xuất từ CSDL KhachHang

            ViewBag.idLoaiKH = idLoaiKH;

            return View(danhSachKhachHang);
        }

        // kết nối DB và tạo form thêm mới khách hàng 
        public ActionResult AddCustomer()
        {
            return View();
        }

        // kết nối DB và nhận value từ form sau đó thêm mới bản ghi vào CSDL
        [HttpPost]
        public ActionResult AddCustomer(KhachHang model, HttpPostedFileBase imageCustomer)
        {
            // 2. thêm mới bản ghi
            PhuongAnhITEntities db = new PhuongAnhITEntities();

            // lưu ảnh vào folder và lưu URL vào DB
            if (ModelState.IsValid && imageCustomer != null && imageCustomer.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imageCustomer.FileName);
                var fileNameExtension = Path.GetExtension(imageCustomer.FileName); // lấy đuôi mở rộng
                if (fileNameExtension == ".webp")
                {
                    fileName = Path.ChangeExtension(fileName, ".jpg"); // đuổi đuôi webp thành jpg
                }
                var filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                imageCustomer.SaveAs(filePath);
                model.Anh = "~/Images/" + fileName;
            }

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
        public ActionResult EditCustomer(KhachHang model, HttpPostedFileBase imageCustomer)
        {
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            var updateModel = db.KhachHangs.Find(model.Id); // tìm đối tượng theo id

            // gán giá trị mới cho updateModel
            updateModel.TenKhachHang = model.TenKhachHang;
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.DiaChi = model.DiaChi;
            updateModel.IdLoaiKhachHang = model.IdLoaiKhachHang;

            // nếu có ảnh mới thì lưu ảnh mới folder và URL mới vào DB
            if (imageCustomer != null)
            {
                var fileName = Path.GetFileName(imageCustomer.FileName);
                var fileNameExtension = Path.GetExtension(imageCustomer.FileName); // lấy đuôi mở rộng
                if (fileNameExtension == ".webp")
                {
                    fileName = Path.ChangeExtension(fileName, ".jpg"); // đuổi đuôi webp thành jpg
                }
                var filePath = Path.Combine(Server.MapPath("~/Images"), fileName);
                imageCustomer.SaveAs(filePath);
                updateModel.Anh = "~/Images/" + fileName;
            }

            db.SaveChanges(); // lưu lại thay đổi

            return RedirectToAction("Index");
        }

        // kết nối DB và xoá khách hàng theo id
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
