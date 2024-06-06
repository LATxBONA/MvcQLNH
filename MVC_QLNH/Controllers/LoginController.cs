using Microsoft.AspNetCore.Mvc;
using MVC_QLNH.Models;

namespace MVC_QLNH.Controllers
{
    public class LoginController : Controller
    {
        MvcQlnhContext db = new MvcQlnhContext();
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("taikhoan")==null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "home");
            }
        }
        [HttpPost]
        public IActionResult Login(TbAccount tk)
        {
            if (HttpContext.Session.GetString("taikhoan")==null)
            {
                var u = db.TbAccounts.Where(x => x.Taikhoan.Equals(tk.Taikhoan) && x.Matkhau.Equals(tk.Matkhau)).FirstOrDefault();
                if (u!=null)
                {
                    HttpContext.Session.SetString("taikhoan", u.Taikhoan.ToString());
                    return RedirectToAction("index", "home");
                }
                // Login failed, return a specific view
                return View("LoginFailed");
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }
    }
}
