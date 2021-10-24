using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public enum TrangthaiHD
    {
        [Display(Name = "Hủy")]
        Huy = -1,
        [Display(Name = "Đang chờ xử lí")]
        Dangchoxuli = 0,
        [Display(Name = "Đã xác nhận")]
        Daxacnhan = 1,
        [Display(Name = "Đang giao")]
        Danggiao = 2,
        [Display(Name = "Đã giao")]
        Dagiao = 3
    }
    public class HoaDon
    {
        [Key]
        public int Mahoadon { get; set; }
        [Display(Name = "Mã Quản Trị"), ForeignKey("QuanTri")]
        public int Maquantri { get; set; }
        [Display(Name = "Mã Khách Hàng"), ForeignKey("KhachHang")]
        public int Makhachhang { get; set; }
        [Display(Name = "Tổng tiền"), Required, Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập giá.")]
        public double Tongtien { get; set; }
        [Display(Name = "Email nhận hàng"), Column(TypeName = "varchar(50)"), Required(ErrorMessage = "Bạn cần nhập email nhận hàng."), MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không phù hợp."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ nhận hàng"), StringLength(250), Required(ErrorMessage = "Bạn cần địa chỉ nhận hàng.")]
        public string Diachi { get; set; }
        [Display(Name = "Ngày đặt"), Required(ErrorMessage = "Bạn cần chọn ngày."), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Ngaydat { get; set; }
        [Display(Name = "Trạng thái")]
        public TrangthaiHD TrangthaiHD { get; set; }
        public QuanTri QuanTri { get; set; }
        public KhachHang KhachHang { get; set; }
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
