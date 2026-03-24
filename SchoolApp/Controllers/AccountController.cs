using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SchoolApp.Controllers
{
    public class AccountController : Controller
    {
        SchoolDBEntities db = new SchoolDBEntities();

        // 1. Trang hiển thị Form Login
        public ActionResult Login()
        {
            return View();
        }

        // 2. Xử lý khi nhấn nút Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = db.tblUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Đăng nhập thành công, lưu vào Session và chuyển đến trang Students
                Session["UserID"] = user.UserID;
                Session["UserName"] = user.Username;
                return RedirectToAction("Index", "Students");
            }
            else
            {
                // Thất bại, hiện thông báo lỗi
                ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
                return View();
            }
        }

        // 3. Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
