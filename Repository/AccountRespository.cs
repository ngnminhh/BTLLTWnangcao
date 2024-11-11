using QLTV.Models;
using System.Security.Principal;

namespace QLTV.Repository
{
    public class AccountRespository : IAccountRepository
    {
        private readonly QLTVContext context;
        public AccountRespository(QLTVContext context)
        {
            this.context = context;
        }
        public void CreateAccount(DtoSignup act, string idUser,HttpContext httpContext)
        {
            int id = context.TblTheMuons.Count() + 1;
            var maTheMuon = "ID" + id;
            TblTaiKhoan newtk = new TblTaiKhoan()
            {
                STaiKhoan = act.STaiKhoan,
                SMatKhau = act.SMatKhau,
                SMaQuyen = "user",
                SMaNguoiDung = act.STaiKhoan
            };
            TblTheMuon newTheMuon = new TblTheMuon()
            {
                SMaTheMuon = maTheMuon,
                DNgayMuon = null,
                DNgayTra = null,
                DNgayTraDuKien = null,
                DNgayTraThucTe = null,
                STrangThai = null,
            };
            TblNguoiDung newuser = new TblNguoiDung()
            {
                SMaNguoiDung=act.STaiKhoan,
                SCccd=act.SCccd,
                SDiaChi = act.SDiaChi,
                DNgaySinh = act.DNgaySinh,
                SMaTheMuon=maTheMuon,
            };
            context.TblTheMuons.Add(newTheMuon);
            context.TblNguoiDungs.Add(newuser);
            context.TblTaiKhoans.Add(newtk);
            context.SaveChanges();
            httpContext.Session.SetString("CurrentAccount", newtk.STaiKhoan);
            httpContext.Session.SetString("Quyen", newtk.SMaQuyen);
        }
        public void UpdateAccount(DtoUpdate act, string idUser)
        {
            var updateAccount = context.TblNguoiDungs.FirstOrDefault(s => s.SMaNguoiDung.Equals(idUser));
            updateAccount.STenNguoiDung = act.STenNguoiDung;
            updateAccount.SDiaChi = act.SDiaChi;
            updateAccount.SCccd = act.SCccd;
            updateAccount.DNgaySinh = act.DNgaySinh;
            context.SaveChanges();
        }
    }
}
