using System.ComponentModel.DataAnnotations;

namespace QLTV.Models
{
    public class DtoBooks
    {
        [Required(ErrorMessage ="Tên sản phẩm không được bỏ trống"),MaxLength(100)]
        public string? STenSach { get; set; }
        [Required(ErrorMessage ="Nhà xuất bản không được bỏ trống"),MaxLength(100)]
        public string? SNhaXuatBan { get; set; }
        [Required(ErrorMessage ="Mô tả không được bỏ trống"),MaxLength(100)]
        public string? SMoTa { get; set; }
        [Required(ErrorMessage ="Số lượng không được bỏ trống"),MaxLength(100)]
        public int? ISoLuong { get; set; }
        [Required(ErrorMessage ="Vui điền trạng thái")]
        public string? STrangThai { get; set; }
        [Required(ErrorMessage ="Giá mượn không được bỏ trống"),MaxLength(100)]
        public double? FGiaTien { get; set; }
        [Required(ErrorMessage ="Vui lòng chọn danh mục")]
        public string? SMaDanhMuc { get; set; }
        [Required(ErrorMessage ="Tác giả không được bỏ trống")]
        public string? STenTacGia { get; set; }
        [Required(ErrorMessage ="Không tìm thấy hình ảnh")]
        public string? SDuongDan { get; set; }
    }
}
