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
            TblTaiKhoan newtk = new TblTaiKhoan()
            {
                STaiKhoan = act.STaiKhoan,
                SMatKhau = act.SMatKhau,
                SMaQuyen = "user",
                SMaNguoiDung = act.STaiKhoan
            };
            TblNguoiDung newuser = new TblNguoiDung()
            {
                SMaNguoiDung=act.STaiKhoan,
                SCccd=act.SCccd,
                SDiaChi = act.SDiaChi,
                DNgaySinh = act.DNgaySinh,
            };
            context.TblNguoiDungs.Add(newuser);
            context.TblTaiKhoans.Add(newtk);
            context.SaveChanges();
            httpContext.Session.SetString("CurrentAccount", newtk.STaiKhoan);
            httpContext.Session.SetString("Quyen", newtk.SMaQuyen);
        }
        public void UpdateAccount(DtoSignup act, string idUser, HttpContext httpContext)
        {

        }
    }
}
