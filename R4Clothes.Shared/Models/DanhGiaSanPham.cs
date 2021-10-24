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
        [Key]
        public int MaDanhGiaSP { get; set; }
        [Display(Name = "Mã khách hàng"), ForeignKey("KhachHang")]
        public int Makhachhang { get; set; }
        [Display(Name = "Mã sản phẩm"), ForeignKey("SanPham")]      
        public int Masanpham { get; set; }
        [Display(Name = "Ngày đánh giá"), Required(ErrorMessage = "Bạn cần chọn ngày."), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Thoigian { get; set; }
        [Display(Name = "Chi tiết"), StringLength(250)]
        public string Chitiet { get; set; }
        public SanPham SanPham { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}
