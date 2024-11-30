using System.ComponentModel.DataAnnotations;

namespace QLTV.Models
{
    public class DtoCategories
    {
        
        [Required(ErrorMessage = "Mã danh mục không được bỏ trống"), MaxLength(100)]
        public string SMaDanhMuc { get; set; } = null!;
        [Required(ErrorMessage = "Tên danh mục không được bỏ trống"), MaxLength(100)]
        public string? STenDanhMuc { get; set; }
        //[AllowHtml]

        [Required(ErrorMessage = "Verify Key không được để trống")]
        [RegularExpression(@"^\D.*\d$", ErrorMessage = "Kí tự cuối cùng phải là 1 chữ số")]

        [StringLength(100,MinimumLength =6,ErrorMessage ="Verify Key yêu cầu tối thiểu 6 kí tự!!!")]
        public string? VerifyKey { get; set; } = "";
        
    }

}
