using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }
        [ForeignKey("HoaDon")]
        public int Mahoadon { get; set; }
        [ForeignKey("SanPham")]
        public int Masanpham { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Bạn cần nhập tên.")]
        [Display(Name = "Tên sản phẩm")]
        public string Tensanpham { get; set; }
        [Required, Range(0, int.MaxValue, ErrorMessage = "Bạn cần nhập số lượng.")]
        [Display(Name = "Số lượng")]
        public int Soluong { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập thành tiền.")]
        [Display(Name = "Thành tiền")]
        public double Thanhtien { get; set; }
        public HoaDon Hoadon { get; set; }
        public SanPham Sanpham { get; set; }
    }
}
