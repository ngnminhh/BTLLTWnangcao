using Microsoft.AspNetCore.Mvc;
using QLTV.Models;
using System.Diagnostics;

namespace QLTV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("homepage")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Trang chủ";
            return View();
        }

        [Route("cart")]
        public IActionResult Cart()
        {
            ViewData["Title"] = "Giỏ hàng";
            return View();
        }
        [Route("itemdetail")]
        public IActionResult ItemDetail()
        {
            ViewData["Title"] = "Chi tiết sản phẩm";
            return View();
        }
        [Route("danhmuc")]
        public IActionResult Category()
        {
            ViewData["Title"] = "Danh mục sách";
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
