using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblSach
    {
        public string SMaSach { get; set; } = null!;
        public string? STenSach { get; set; }
        public string? SNhaXuatBan { get; set; }
        public string? SMoTa { get; set; }
        public int? ISoLuong { get; set; }
        public string? STrangThai { get; set; }
        public double? FGiaTien { get; set; }
        public string? SMaDanhMuc { get; set; }
        public string? STenTacGia { get; set; }
        public string? SDuongDan { get; set; }

        public virtual TblDanhMuc? SMaDanhMucNavigation { get; set; }
        public virtual TblDanhSachMuon? TblDanhSachMuon { get; set; }
    }
}
