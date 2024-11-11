using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QLTV.Models;
using QLTV.Repository;
using System.Net.WebSockets;
using System.Security.Principal;
namespace QLTV.Controllers
{
    public class AccountController : Controller
    {  
        private readonly QLTVContext context;
        private readonly IAccountRepository iaccount;
        public AccountController(QLTVContext context,IAccountRepository iaccount)
        {
            this.context = context;
            this.iaccount = iaccount;
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
            var account = context.TblTaiKhoans.FirstOrDefault(s => s.STaiKhoan.Equals(act.STaiKhoan) && s.SMatKhau.Equals(act.SMatKhau));
            if(!ModelState.IsValid)
            {
                return View(act);
            }
            if (account == null)
            {
                TempData["NoAccount"] = "Tài khoản hoặc mật khẩu không đúng";
                return View();
            }
            HttpContext.Session.SetString("CurrentAccount", account.STaiKhoan);
            HttpContext.Session.SetString("Quyen", account.SMaQuyen);
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
            string idUser = act.STaiKhoan;
            var httpContext = HttpContext;
            if (!ModelState.IsValid)
            {
                return View(act);
            }
            try
            {
                iaccount.CreateAccount(act,idUser, httpContext);
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
                    TempData["ErrorMessage"] = ex.InnerException.Message;
                }

                return RedirectToAction("SignUp","Account");
            }
            return View();
        }
        [Route("update_info")]
        public IActionResult Info()
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            string currentUser = HttpContext.Session.GetString("CurrentAccount");
            var userInfo =context.TblNguoiDungs.FirstOrDefault(s=>s.SMaNguoiDung.Equals(currentUser));
            if (userInfo != null)
            {
                ViewData["CurrentAccount"] = currentUser;
                ViewData["Quyen"] = HttpContext.Session.GetString("Quyen");
            }
            DtoUpdate udtUser = new DtoUpdate()
            {
                STaiKhoan=currentUser,
                STenNguoiDung=userInfo.STenNguoiDung,
                SCccd=userInfo.SCccd,
                SDiaChi=userInfo.SDiaChi,
                DNgaySinh=userInfo.DNgaySinh,
                SMaTheMuon=userInfo.SMaTheMuon,
            };
            return View(udtUser);
        }
        [Route("update_info")]
        [HttpPost]
        public IActionResult Info(DtoUpdate uptDto)
        {
            var currentAccount = HttpContext.Session.GetString("CurrentAccount");
            if (currentAccount != null)
            {
                ViewData["CurrentAccount"] = currentAccount;
                ViewData["Quyen"] = HttpContext.Session.GetString("Quyen");
            }

            if(!ModelState.IsValid)
            {
                return View(uptDto);
            }
            iaccount.UpdateAccount(uptDto, currentAccount);
            TempData["UpdateSuccess"] = "Cập nhật thành công";
            return RedirectToAction("Info","Account");
        }
        [Route("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("CurrentAccount");
            HttpContext.Session.Remove("Quyen");
            return RedirectToAction("Index", "Account");
        }
    }
}
