﻿using Microsoft.EntityFrameworkCore;
using QLTV.Models;

namespace QLTV.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly QLTVContext context;
        public AdminRepository(QLTVContext context)
        {
            this.context = context;
        }
        public IEnumerable<dynamic> GetDanhMuc()
        {
            var lstDanhMuc = context.TblDanhMucs.ToList();
            return lstDanhMuc;
        }
        public IEnumerable<dynamic> GetListSach()
        {
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
            return lstBooks;
        }
        public IEnumerable<dynamic> UpdateSach(IFormCollection form)
        {
            var idBook = form["bookID"];
            var bookName = form["bookName"];
            var bookNXB = form["bookNXB"];
            var bookDesc = form["bookDesc"];
            var bookAmount = form["bookAmount"];
            var bookStatus = form["bookStatus"];
            var bookPrice = form["bookPrice"];
            var bookCategory = form["bookCategory"];
            var bookAuthor = form["bookAuthor"];

            var bookUpdate = context.TblSaches.FirstOrDefault(s => s.SMaSach.Equals(idBook));
            bookUpdate.STenSach = bookName;
            bookUpdate.SNhaXuatBan = bookNXB;
            bookUpdate.SMoTa = bookDesc;
            bookUpdate.ISoLuong = int.Parse(bookAmount);
            bookUpdate.STrangThai = bookStatus;
            bookUpdate.FGiaTien = float.Parse(bookPrice);
            bookUpdate.SMaDanhMuc = bookCategory;
            bookUpdate.STenTacGia = bookAuthor;
            context.SaveChanges();

            var lstBooks = (
                    from b in context.TblSaches
                    join c in context.TblDanhMucs
                    on b.SMaDanhMuc equals c.SMaDanhMuc
                    where b.SMaSach.Equals(idBook)
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
            return lstBooks;
        }

        public IEnumerable<dynamic> UpdateDM(IFormCollection form)
        {
            var id = form["id"];
            var tendm = form["tendm"];

            try
            {
                var CategoryUpdate = context.TblDanhMucs.FirstOrDefault(e => e.SMaDanhMuc.Equals(id));
                if (CategoryUpdate == null)
                {
                    throw new InvalidOperationException("Category not found");
                }

                CategoryUpdate.STenDanhMuc = tendm;
                context.SaveChanges();

                var lstDM = (
                    from c in context.TblDanhMucs
                    select new
                    {
                        c.SMaDanhMuc,
                        c.STenDanhMuc
                    }
                ).ToList();

                return lstDM;
            }
            catch (DbUpdateException dbEx)
            {
                // Lỗi update cơ sở dữ liệu
                Console.WriteLine("Error occurred while saving the changes: " + dbEx.InnerException?.Message);
                throw;
            }
            catch (Exception ex)
            {
                // Lỗi khác
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }



    }
}
