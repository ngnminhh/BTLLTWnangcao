using QLTV.Models;

namespace QLTV.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly QLTVContext context;
        public HomeRepository(QLTVContext context)
        {
            this.context = context;
        }
        public IEnumerable<dynamic> GetDMBooks()
        {
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
            return result;
        }
        public IEnumerable<dynamic> GetItemDetail(string id)
        {
            var item = context.TblSaches.Find(id);
            var list = (
                    from b in context.TblSaches
                    join c in context.TblDanhMucs
                    on b.SMaDanhMuc equals c.SMaDanhMuc
                    where c.SMaDanhMuc == item.SMaDanhMuc
                    select new
                    {
                        TenSachChon = item.STenSach,
                        TacGiaChon = item.STenTacGia,
                        NXBChon = item.SNhaXuatBan,
                        TrangThaiChon = item.STrangThai,
                        GiaTienChon = item.FGiaTien,
                        DuongDanChon = item.SDuongDan,
                        SanPhamLienQuan = context.TblSaches
                               .Where(p => p.SMaDanhMuc == c.SMaDanhMuc)
                               .Select(p => new { p.SMaSach, p.STenSach, p.STenTacGia, p.SNhaXuatBan, p.ISoLuong, p.STrangThai, p.FGiaTien, p.SMaDanhMuc, p.SDuongDan })
                               .OrderBy(x => Guid.NewGuid()).Take(4).ToList()
                    }
                ).Take(1).ToList();
            return list;
        }
        public IEnumerable<dynamic> GetBookWithCategory(string id)
        {
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
            return lstSachTheoDM;
        }
        public IEnumerable<dynamic> GetListBooksBorrow(string currentUser)
        {
            var lstSachMuon = (
                    from tk in context.TblNguoiDungs
                    join tm in context.TblTheMuons on tk.SMaTheMuon equals tm.SMaTheMuon
                    join dsm in context.TblDanhSachMuons on tm.SMaTheMuon equals dsm.SMaTheMuon
                    join s in context.TblSaches on dsm.SMaSach equals s.SMaSach
                    where tk.SMaNguoiDung.Equals(currentUser)
                    group new { s.SMaSach, s.STenSach, tm } by tm.SMaTheMuon into grouped
                    select new
                    {
                        SMaTheMuon = grouped.Key,
                        STaiKhoan = grouped.Max(g => g.tm.DNgayMuon),
                        DNgayMuon = grouped.Max(g => g.tm.DNgayMuon),
                        DNgayTra = grouped.Max(g => g.tm.DNgayTra),
                        DNgayTraDuKien = grouped.Max(g => g.tm.DNgayTraDuKien),
                        DNgayTraThucTe = grouped.Max(g => g.tm.DNgayTraThucTe),
                        STrangThai = grouped.Max(g => g.tm.STrangThai),
                        SachDetails = grouped.Select(g => new
                        {
                            g.SMaSach,
                            g.STenSach
                        }).ToList()
                    }
                ).ToList();
            return lstSachMuon;
        }
    }
}
