using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public class DanhGiaSanPham
    {
        [ForeignKey("KhachHang")]
        [Display(Name = "Mã khách hàng")]
        public int Makhachhang { get; set; }
        [ForeignKey("SanPham")]
        [Display(Name = "Mã sản phẩm")]      
        public int Masanpham { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Bạn cần chọn ngày."), Display(Name = "Ngày đặt")]
        public DateTime Thoigian { get; set; }
        [StringLength(250)]
        [Display(Name = "Chi tiết")]
        public string Chitiet { get; set; }
    }
}
