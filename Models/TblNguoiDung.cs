﻿using System;
using System.Collections.Generic;

namespace QLTV.Models
{
    public partial class TblNguoiDung
    {
        public TblNguoiDung()
        {
            TblTaiKhoans = new HashSet<TblTaiKhoan>();
        }

        public string SMaNguoiDung { get; set; } = null!;
        public string? STenNguoiDung { get; set; }
        public string? SCccd { get; set; }
        public string? SDiaChi { get; set; }
        public DateTime? DNgaySinh { get; set; }
        public string? SMaTheMuon { get; set; }

        public virtual TblTheMuon? SMaTheMuonNavigation { get; set; }
        public virtual ICollection<TblTaiKhoan> TblTaiKhoans { get; set; }
    }
}
