using System.ComponentModel.DataAnnotations;

namespace QLTV.Models
{
    public class DtoUpdate
    {
        public string STaiKhoan { get; set; } = "";

        [Required(ErrorMessage = "Họ tên không được để trống"), MaxLength(100)]
        public string STenNguoiDung { get; set; } = "";
        [Required(ErrorMessage = "CCCD không được để trống"), MaxLength(100)]
        public string? SCccd { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống"), MaxLength(100)]
        public string? SDiaChi { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        public DateTime? DNgaySinh { get; set; }
        public string? SMaTheMuon { get; set; }
    }
}
