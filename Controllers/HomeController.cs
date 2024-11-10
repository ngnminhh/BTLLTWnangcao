using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.Models;
using QLTV.Repository;
using System.Diagnostics;

namespace QLTV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLTVContext context;
        private readonly IHomeRepository ihome;
        public HomeController(ILogger<HomeController> logger, QLTVContext context,IHomeRepository ihome)
        {
            _logger = logger;
            this.context = context;
            this.ihome = ihome;
        }

        [Route("homepage")]
        public IActionResult Index()
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            var result = ihome.GetDMBooks();
            var currentAccount = HttpContext.Session.GetString("CurrentAccount");
            if (currentAccount != null)
            {
                ViewData["CurrentAccount"] = currentAccount;
                ViewData["Quyen"] = HttpContext.Session.GetString("Quyen");
                return View(result);
            }
            //List<object> resultList = result.Cast<object>().ToList();
            return RedirectToAction("Login","Account");
        }

        [Route("cart")]
        public IActionResult Cart()
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            ViewData["Title"] = "Giỏ hàng";
            var currentAccount = HttpContext.Session.GetString("CurrentAccount");
            if (currentAccount != null)
            {
                ViewData["CurrentAccount"] = currentAccount;
                ViewData["Quyen"] = HttpContext.Session.GetString("Quyen");
            }
            var lstSachMuon = ihome.GetListBooksBorrow(currentAccount);
            return View(lstSachMuon);
        }
        [Route("itemdetail")]
        public IActionResult ItemDetail(string id)
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            ViewData["Title"] = "Chi tiết sản phẩm";
            var currentAccount = HttpContext.Session.GetString("CurrentAccount");
            if (currentAccount != null)
            {
                ViewData["CurrentAccount"] = currentAccount;
                ViewData["Quyen"] = HttpContext.Session.GetString("Quyen");
            }
            var item = context.TblSaches.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index","Home");
            }
            var lstSachTheoDM = ihome.GetItemDetail(id);
            return View(lstSachTheoDM);
        }
        [Route("danhmuc")]
        public IActionResult Category(string id)
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            ViewData["Title"] = "Danh mục sách";
            var currentAccount = HttpContext.Session.GetString("CurrentAccount");
            if (currentAccount != null)
            {
                ViewData["CurrentAccount"] = currentAccount;
                ViewData["Quyen"] = HttpContext.Session.GetString("Quyen");
            }
            var lstSachTheoDM = ihome.GetBookWithCategory(id);
            return View(lstSachTheoDM);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
