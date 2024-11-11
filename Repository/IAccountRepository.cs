using QLTV.Models;

namespace QLTV.Repository
{
    public interface IAccountRepository
    {
        public void CreateAccount(DtoSignup act, string idUser, HttpContext httpContext);
        public void UpdateAccount(DtoUpdate act, string idUser);

    }
}
