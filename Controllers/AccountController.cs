using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLTV.Models;
namespace QLTV.Controllers
{
    public class AccountController : Controller
    {  
        private readonly QLTVContext context;
        public AccountController(QLTVContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Đăng nhập";
            return View("Login");
        }
        [Route("login")]
        public IActionResult Login()
        {
            ViewData["Title"] = "Đăng nhập";
            return View();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(DtoLogin act)
        {
            if(!ModelState.IsValid)
            {
                return View(act);
            }
            return RedirectToAction("Index","Home");
        }
        [Route("signup")]
        public IActionResult SignUp(){
            ViewData["Title"] = "Đăng ký";
            return View();
        }
        [Route("signup")]
        [HttpPost]
        public IActionResult SignUp(DtoSignup act)
        {
            ViewData["Title"] = "Đăng ký";
            var idUser = act.STaiKhoan;
            if (!ModelState.IsValid)
            {
                return View(act);
            }
            //var checkUser=context.TblTaiKhoans.Find(idUser);
            //if(checkUser == null)
            //{
            //    TblTaiKhoan newtk = new TblTaiKhoan()
            //    {
            //        STaiKhoan = act.STaiKhoan,
            //        SMatKhau = act.SMatKhau,
            //        SMaQuyen = "user",
            //        SMaNguoiDung = null
            //    };
            //    context.TblTaiKhoans.Add(newtk);
            //    context.SaveChanges();
            //    return RedirectToAction("Index", "Home");
            //}
            try
            {
                TblTaiKhoan newtk = new TblTaiKhoan()
                {
                    STaiKhoan = act.STaiKhoan,
                    SMatKhau = act.SMatKhau,
                    SMaQuyen = "user",
                    SMaNguoiDung = null
                };
                context.TblTaiKhoans.Add(newtk);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate key"))
                {
                    TempData["ErrorMessage"] = "Tài khoản đã tồn tại";
                }
                else
                {
                    TempData["ErrorMessage"] = "Có lỗi xảy ra";
                }

                return RedirectToAction("SignUp","Account");
            }
            return View();
        }
    }
}
