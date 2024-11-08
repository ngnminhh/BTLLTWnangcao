using System.ComponentModel.DataAnnotations;

namespace QLTV.Models
{
    public class DtoLogin
    {
        [Required(ErrorMessage = "Tài khoản không được để trống"), MaxLength(100)]
        public string STaiKhoan { get; set; } = "";

        [Required(ErrorMessage = "Mật khẩu không được để trống"), MaxLength(100)]
        public string? SMatKhau { get; set; } = "";
    }
}
