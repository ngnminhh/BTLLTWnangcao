using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblDanhSachMuon
    {
        public string? SMaDanhSach { get; set; }
        public string SMaSach { get; set; } = null!;
        public string SMaTheMuon { get; set; } = null!;

        public virtual TblSach SMaSachNavigation { get; set; } = null!;
        public virtual TblTheMuon SMaTheMuonNavigation { get; set; } = null!;
    }
}
