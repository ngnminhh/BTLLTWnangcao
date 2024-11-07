using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblDanhSachMuon
    {
        public string SMaDanhSach { get; set; } = null!;
        public string? SMaSach { get; set; }
        public string? SMaTheMuon { get; set; }

        public virtual TblSach SMaDanhSachNavigation { get; set; } = null!;
        public virtual TblTheMuon? SMaTheMuonNavigation { get; set; }
    }
}
