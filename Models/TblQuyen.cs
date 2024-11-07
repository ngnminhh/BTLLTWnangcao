using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblQuyen
    {
        public TblQuyen()
        {
            TblTaiKhoans = new HashSet<TblTaiKhoan>();
        }

        public string SId { get; set; } = null!;
        public string? STenQuyen { get; set; }
        public int? IMaQuyen { get; set; }

        public virtual ICollection<TblTaiKhoan> TblTaiKhoans { get; set; }
    }
}
