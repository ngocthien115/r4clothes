using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public enum Gioitinh
    {
        [Display(Name = "Nam")]
        Nam,
        [Display(Name = "Nữ")]
        Nu,
        [Display(Name = "LGBT")]
        LGBT,
    }
    public class KhachHang
    {
        [Key]
        public int Makhachhang { get; set; }
        [Display(Name = "Họ & Tên"), Required(ErrorMessage = "Bạn cần nhập họ tên."), StringLength(150)]
        public string Tenkhachhang { get; set; }
        [Display(Name = "Email"), Column(TypeName = "varchar(50)"), Required(ErrorMessage = "Bạn cần nhập email."), MaxLength(50) ]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email không phù hợp."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"), Required(ErrorMessage = "Bạn cần chọn ngày sinh")]
        public DateTime? NgaySinh { get; set; }
        [Display(Name = "Giới tính")]
        public Gioitinh Gioitinh { get; set; }
        [Display(Name = "Địa Chỉ"), StringLength(250), Required(ErrorMessage = "Bạn cần địa chỉ.")]       
        public string Diachi { get; set; }
        [Display(Name = "Số phone"), Column(TypeName = "varchar(15)"), Required(ErrorMessage = "Bạn cần nhập số điện thoại."), MaxLength(15)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số điện thoại không phù hợp.")]
        public string Sodienthoai { get; set; }
        [Display(Name = "Hình"), Column(TypeName = "nvarchar(100)"), StringLength(100)]
        public string Hinh { get; set; }
        [NotMapped]
        [Display(Name = "Chọn hình")]
        public IBrowserFile ImageFile { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Trangthai { get; set; }       
        [Display(Name = "Mật khẩu"), Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string Matkhau { get; set; }
        public List<DanhGiaSanPham> DanhGiaSanPhams { get; set; }
        public List<HoaDon> HoaDon { get; set; }
        public List<ChiaSe> ChiaSes { get; set; }
    }
}
