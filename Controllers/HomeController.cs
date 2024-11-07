using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV.Models;
using System.Diagnostics;

namespace QLTV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLTVContext context;
        public HomeController(ILogger<HomeController> logger, QLTVContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [Route("homepage")]
        public IActionResult Index()
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            var danhmuc = context.TblDanhMucs.ToList();
            var result = danhmuc.Select(c => new
            {
                TenDanhMuc = c.STenDanhMuc,
                MaDanhMuc = c.SMaDanhMuc,
                SanPham = context.TblSaches
                               .Where(p => p.SMaDanhMuc == c.SMaDanhMuc)
                               .Select(p => new { p.SMaSach, p.STenSach, p.STenTacGia, p.SNhaXuatBan, p.ISoLuong, p.STrangThai, p.FGiaTien, p.SMaDanhMuc, p.SDuongDan })
                               .Take(4)
                               .ToList()
            }).Take(3).ToList();
            //List<object> resultList = result.Cast<object>().ToList();

            return View(result);
        }

        [Route("cart")]
        public IActionResult Cart()
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            ViewData["Title"] = "Giỏ hàng";
            return View();
        }
        [Route("itemdetail")]
        public IActionResult ItemDetail(string id)
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            ViewData["Title"] = "Chi tiết sản phẩm";
            return View();
        }
        [Route("danhmuc")]
        public IActionResult Category(string id)
        {
            ViewData["DanhMuc"] = context.TblDanhMucs?.ToList();
            ViewData["Title"] = "Danh mục sách";

            var lstSachTheoDM = (
                    from b in context.TblSaches
                    join c in context.TblDanhMucs
                    on b.SMaDanhMuc equals c.SMaDanhMuc
                    where c.SMaDanhMuc == id
                    select new
                    {
                        TenDanhMuc = c.STenDanhMuc,
                        MaDanhMuc = c.SMaDanhMuc,
                        SanPham = context.TblSaches
                               .Where(p => p.SMaDanhMuc == c.SMaDanhMuc)
                               .Select(p => new { p.SMaSach, p.STenSach, p.STenTacGia, p.SNhaXuatBan, p.ISoLuong, p.STrangThai, p.FGiaTien, p.SMaDanhMuc, p.SDuongDan })
                               .ToList()
                    }
                ).Take(1).ToList();
            return View(lstSachTheoDM);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
