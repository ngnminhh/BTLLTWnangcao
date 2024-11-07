using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblTheMuon
    {
        public TblTheMuon()
        {
            TblDanhSachMuons = new HashSet<TblDanhSachMuon>();
            TblNguoiDungs = new HashSet<TblNguoiDung>();
        }

        public string SMaTheMuon { get; set; } = null!;
        public DateTime? DNgayMuon { get; set; }
        public DateTime? DNgayTra { get; set; }
        public DateTime? DNgayTraDuKien { get; set; }
        public DateTime? DNgayTraThucTe { get; set; }
        public string? STrangThai { get; set; }

        public virtual ICollection<TblDanhSachMuon> TblDanhSachMuons { get; set; }
        public virtual ICollection<TblNguoiDung> TblNguoiDungs { get; set; }
    }
}
