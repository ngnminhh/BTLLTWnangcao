using Microsoft.AspNetCore.Mvc;
using QLTV.Models;
using QLTV.Repository;

namespace QLTV.Controllers
{
    public class AdminController : Controller
    {
        private readonly QLTVContext context;
        private readonly IAdminRepository iadmin;
        public AdminController(QLTVContext context, IAdminRepository iadmin)
        {
            this.context = context;
            this.iadmin = iadmin;
        }
        [Route("getdanhmuc")]
        public JsonResult GetDanhMuc()
        {
            var lstDanhMuc = iadmin.GetDanhMuc();
            return Json(lstDanhMuc);
        }
        [Route("books_manage")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Quản lý sản phẩm";
            var lstBooks = (
                    from b in context.TblSaches
                    join c in context.TblDanhMucs
                    on b.SMaDanhMuc equals c.SMaDanhMuc
                    select new
                    {
                        b.SMaSach,
                        b.STenSach,
                        b.SNhaXuatBan,
                        b.SMoTa,
                        b.ISoLuong,
                        b.STrangThai,
                        b.FGiaTien,
                        b.SMaDanhMuc,
                        b.STenTacGia,
                        b.SDuongDan,
                        c.STenDanhMuc
                    }
                ).ToList();
            return View("BooksManage", lstBooks);
            // return Json(lstBooks);
        }
        [Route("add_book")]
        public JsonResult AddBook(IFormCollection form)
        {
            int id = context.TblSaches.Count() + 1;
            var idBook = "S0" + id;
            var bookName = form["bookName"];
            var bookNXB = form["bookNXB"];
            var bookDesc = form["bookDesc"];
            var bookAmount = form["bookAmount"];
            var bookStatus = form["bookStatus"];
            var bookPrice = form["bookPrice"];
            var bookCategory = form["bookCategory"];
            var bookAuthor = form["bookAuthor"];

            TblSach newSach = new TblSach()
            {
                SMaSach = idBook,
                STenSach = bookName,
                SNhaXuatBan = bookNXB,
                SMoTa = bookDesc,
                ISoLuong = int.Parse(bookAmount),
                STrangThai = bookStatus,
                FGiaTien = float.Parse(bookPrice),
                SMaDanhMuc = bookCategory,
                STenTacGia = bookAuthor,
                SDuongDan = "megazine11.jpg"
            };
            context.TblSaches.Add(newSach);
            context.SaveChanges();
            return Json(newSach);
        }
        [Route("update_book")]
        [HttpPost]
        public JsonResult UpdateBook(IFormCollection form)
        {
            var lstBooks = iadmin.UpdateSach(form);
            return Json(lstBooks);
        }

        [Route("delete_book")]
        [HttpPost]
        public IActionResult DeleteBook(IFormCollection form)
        {
            var bookID = form["bookID"];
            var delSach = context.TblSaches.FirstOrDefault(s => s.SMaSach.Equals(bookID));
            context.TblSaches.Remove(delSach);
            context.SaveChanges(true);
            return Ok("Đã xóa sản phẩm");
        }
        [Route("account_manage")]
        public IActionResult Account()
        {
            ViewData["Title"] = "Quản lý người dùng";
            var lstBooks = (
                    from b in context.TblTaiKhoans
                    join c in context.TblNguoiDungs
                    on b.SMaNguoiDung equals c.SMaNguoiDung
                    select new
                    {
                        b.STaiKhoan,
                        b.SMatKhau,
                        b.SMaQuyen,
                        b.SMaNguoiDung,
                        c.STenNguoiDung,
                        c.SCccd,
                        c.SDiaChi,
                        c.DNgaySinh
                    }
                ).ToList();
            TempData["ListAccount"] = lstBooks;
            return View("AccountsManage");
        }
        [Route("create_account")]
        [HttpPost]
        public IActionResult AddAccount(DtoSignup dtoSignup)
        {
            if (!ModelState.IsValid)
            {
                return View("AccountsManage", dtoSignup);
            }
            TblTaiKhoan newTK = new TblTaiKhoan()
            {
                STaiKhoan = dtoSignup.STaiKhoan,
                SMatKhau = dtoSignup.SMatKhau,
                SMaQuyen = "user",
                SMaNguoiDung = dtoSignup.STaiKhoan
            };
            TblNguoiDung newUser = new TblNguoiDung()
            {
                SMaNguoiDung = dtoSignup.STaiKhoan,
                STenNguoiDung = null,
                SCccd = dtoSignup.SCccd,
                SDiaChi = dtoSignup.SDiaChi,
                DNgaySinh = DateTime.Parse(dtoSignup.DNgaySinh.ToString()),
            };
            context.TblNguoiDungs.Add(newUser);
            context.TblTaiKhoans.Add(newTK);
            context.SaveChanges();
            TempData["AddSuccess"] = "Thêm người dùng thành công";
            return RedirectToAction("Account", "Admin");
        }
        [Route("edit_account")]
        [HttpPost]
        public IActionResult Account(IFormCollection form)
        {
            ViewData["Title"] = "Quản lý người dùng";
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
            }
            var taikhoan = form["STaiKhoan"];
            var matkhau = form["SMatKhau"];
            var cccd = form["SCccd"];
            var diachi = form["SDiaChi"];
            var ngaysinh = form["DNgaySinh"];

            var user = context.TblNguoiDungs.FirstOrDefault(u => u.SMaNguoiDung.Equals(taikhoan));
            user.SCccd = cccd;
            user.SDiaChi = diachi;
            user.DNgaySinh = DateTime.Parse(ngaysinh.ToString());
            var account=context.TblTaiKhoans.FirstOrDefault(a => a.STaiKhoan.Equals(taikhoan));
            account.SMatKhau = matkhau;

            context.TblNguoiDungs.Update(user);
            context.TblTaiKhoans.Update(account);
            context.SaveChanges();

            return Json(new { succes = true, message="Cập nhật người dùng thành công",taikhoan=taikhoan,matkhau=matkhau,cccd=cccd,diachi=diachi,ngaysinh=ngaysinh });
        }

        [Route("del_account")]
        [HttpPost]
        public JsonResult DeleteAccount(IFormCollection form){
            var taikhoan=form["STaiKhoan"];
            TblTaiKhoan delTk=context.TblTaiKhoans.FirstOrDefault(s=>s.STaiKhoan.Equals(taikhoan));
            TblNguoiDung delNd=context.TblNguoiDungs.FirstOrDefault(s=>s.SMaNguoiDung.Equals(taikhoan));

            context.TblTaiKhoans.Remove(delTk);
            context.TblNguoiDungs.Remove(delNd);
            context.SaveChanges();
            return Json(new{success=true,data=taikhoan});
        }
        [Route("cart_manage")]
        public IActionResult Cart()
        {
            ViewData["Title"] = "Quản lý thẻ mượn";
            return View();
        }
    }
}
