using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblTaiKhoan
    {
        public string STaiKhoan { get; set; } = null!;
        public string? SMatKhau { get; set; }
        public string? SMaQuyen { get; set; }
        public string SMaNguoiDung { get; set; } = null!;

        public virtual TblNguoiDung SMaNguoiDungNavigation { get; set; } = null!;
        public virtual TblQuyen? SMaQuyenNavigation { get; set; }
    }
}
