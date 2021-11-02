using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
        [Key]
        public int MaChiaSe { get; set; }
  
        [Display(Name = "Mã khách hàng"), ForeignKey("KhachHang")]
        public int Makhachhang { get; set; }
  
        [Display(Name = "Mã sản phẩm"), ForeignKey("SanPham")]
        public int Masanpham { get; set; }
  
        [Display(Name = "Họ tên người nhận"), Column(TypeName = "nvarchar(100)"), Required(ErrorMessage = "Bạn cần nhập họ tên người nhận.")]
        public string Hoten { get; set; }
  
        [Display(Name = "Email người nhận"), Column(TypeName = "varchar(50)"), Required(ErrorMessage = "Bạn cần nhập email người nhận."), MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không phù hợp."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
  
        [Display(Name = "Ngày chia sẻ"), Required(ErrorMessage = "Bạn cần chọn ngày."), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Thoigian { get; set; }
  
        public SanPham SanPham { get; set; }
        public KhachHang KhachHang { get; set; }
}
