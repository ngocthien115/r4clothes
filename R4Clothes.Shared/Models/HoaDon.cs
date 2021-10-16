using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public enum Trangthaidonhang
    {
        [Display(Name = "Mới đặt")]
        Moidat = 1,
        [Display(Name = "Đang giao")]
        Danggiao = 2,
        [Display(Name = "Đã giao")]
        Dagiao = 3
    }
    public class HoaDon
    {
        [Key]
        public int Mahoadon { get; set; }
        [ForeignKey("KhachHang")]
        public int Makhachhang { get; set; }
        [Required, Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập giá.")]
        [Display(Name = "Tổng tiền")]
        public double Tongtien { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Bạn cần chọn ngày."), Display(Name = "Ngày đặt")]
        public DateTime Ngaydat { get; set; }
        [Display(Name = "Trạng thái")]
        public Trangthaidonhang Trangthaidonhang { get; set; }
        public KhachHang Khachhang { get; set; }
        public List<ChiTietHoaDon> Chitiethoadons { get; set; }
    }
}
