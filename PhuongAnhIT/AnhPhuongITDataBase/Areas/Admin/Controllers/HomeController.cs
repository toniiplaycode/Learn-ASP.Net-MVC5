using AnhPhuongITDataBase.Models;
using System.Linq;
using System.Web.Mvc;

namespace AnhPhuongITDataBase.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult QuanLySP()
        {
            // nếu chưa đăng nhập (chưa có Session) thì không thể vào được trang Index 
            if (Session["admin"] == null)
            {
                return RedirectToAction("SignIn");
            }
            else
            {
                return View();
            }
        }
        public ActionResult QuanLyTaiKhoanKH()
        {
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            QuanTriVien QTV = (QuanTriVien)Session["admin"];

            if (Session["admin"] == null)
            {
                return RedirectToAction("SignIn");
            }

            int ktraQuyen = db.QuanTriViens.Count(m => m.Id == QTV.Id && m.LaQuanLy == 1);

            if (ktraQuyen == 1)
            {
                return View();
            }
            else
            {
                TempData["error"] = "Bạn không có quyền vào Quản Lý Tài Khoản KH !";
                return RedirectToAction("SignIn");
            }
        }
        public ActionResult QuanLyTaiKhoanNV()
        {
            PhuongAnhITEntities db = new PhuongAnhITEntities();
            QuanTriVien QTV = (QuanTriVien)Session["admin"];

            if (Session["admin"] == null)
            {
                return RedirectToAction("SignIn");
            }

            int ktraQuyen = db.QuanTriViens.Count(m => m.Id == QTV.Id && m.LaQuanLy == 1);

            if (ktraQuyen == 1)
            {
                return View();
            }
            else
            {
                TempData["error"] = "Bạn không có quyền vào Quản Lý Tài Khoản NV !";
                return RedirectToAction("SignIn");
            }
        }

        public ActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string userName, string password)
        {
            PhuongAnhITEntities db = new PhuongAnhITEntities();

            var TKAdmin = db.QuanTriViens.SingleOrDefault(m => m.TenQuanTriVien == userName && m.MatKhau == password);

            if (TKAdmin != null)
            {
                // lưu lại Session
                Session["admin"] = TKAdmin;
                return RedirectToAction("QuanLySP");

            }
            else
            {
                // TemData giống giống ViewBag
                TempData["error"] = "Tài khoản hoặc mật khẩu sai !";
                return View();
            }
        }

        public ActionResult SignOut()
        {
            // xoá Session
            Session.Remove("admin");
            return RedirectToAction("SignIn");
        }
    }
}