using System.Web.Mvc;

namespace AnhPhuongITDataBase.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
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

        public ActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string userName, string password)
        {

            // hard code nhập userName và password
            if (userName.ToLower() == "thanhtoan" && password == "123")
            {
                // lưu lại Session
                Session["admin"] = userName;
                return RedirectToAction("Index");
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