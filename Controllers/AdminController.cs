using Microsoft.AspNetCore.Mvc;

namespace QLTV.Controllers
{
    public class AdminController : Controller
    {
        [Route("books_manage")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Quản lý sản phẩm";
            return View("BooksManage");
        }
        [Route("account_manage")]
        public IActionResult Account()
        {
            ViewData["Title"] = "Quản lý người dùng";
            return View();
        }
        [Route("cart_manage")]
        public IActionResult Cart()
        {
            ViewData["Title"] = "Quản lý thẻ mượn";
            return View();
        }
    }
}
