using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblDanhMuc
    {
        public TblDanhMuc()
        {
            TblSaches = new HashSet<TblSach>();
        }

        public string SMaDanhMuc { get; set; } = null!;
        public string? STenDanhMuc { get; set; }
        public string? VerifyKey { get; set; }

        public virtual ICollection<TblSach> TblSaches { get; set; }
    }
}
