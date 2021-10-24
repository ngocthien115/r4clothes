using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public class QuanTri
    {
        [Key]
        public int Maquantri { get; set; }
        [Display(Name = "Tài khoản"), Column(TypeName = "nvarchar(100)"), Required(ErrorMessage = "Bạn cần nhập tài khoản.")]
        public string Taikhoan { get; set; }
        [Display(Name = "Họ tên"), Column(TypeName = "nvarchar(100)"), Required(ErrorMessage = "Bạn cần nhập họ tên.")]
        public string Hoten { get; set; }
        [Display(Name = "Mật khẩu"), Column(TypeName = "varchar(50)"), MaxLength(50), DataType(DataType.Password)]
        public string Matkhau { get; set; }
        public List<HoaDon> HoaDons { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
