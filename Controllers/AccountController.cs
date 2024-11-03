using Microsoft.AspNetCore.Mvc;

namespace QLTV.Controllers
{
    public class AccountController : Controller
    {
        [Route("login")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Đăng nhập";
            return View("Login");
        }
        [Route("signup")]
        public IActionResult SignUp(){
            ViewData["Title"] = "Đăng ký";
            return View("SignUp");
        }
    }
}
