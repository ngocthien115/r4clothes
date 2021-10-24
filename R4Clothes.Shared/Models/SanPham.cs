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
    public enum TrangthaiSP
    {
        [Display(Name = "Sử dụng")]
        Sudung = 1,
        [Display(Name = "Vô hiệu hóa")]
        Vohieuhoa = 2
    }
    public enum Dacbiet
    {
        [Display(Name = "Giảm giá")]
        Giamgia = 1,
        [Display(Name = "Sản phẩm mới")]
        Sanphammoi = 2
    }
    public class SanPham
    {
        [Key]
        public int Masanpham { get; set; }
        [Display(Name = "Tên sản phẩm"), Required(ErrorMessage = "Bạn cần nhập tên."), StringLength(250)]
        public string Tensanpham { get; set; }
        [Display(Name = "Mã Quản Trị"), ForeignKey("QuanTri")]
        public int Maquantri { get; set; }
        [Display(Name = "Mã loại"), ForeignKey("LoaiSanPham")]
        [Required(ErrorMessage = "Bạn cần chọn mã loại."), Range(1, int.MaxValue, ErrorMessage = "Bạn cần chọn mã loại.")]
        public int Maloai { get; set; }
        public int Soluong { get; set; }       
        [Required(ErrorMessage = "Bạn cần nhập giá."), Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập giá.")]
        [Display(Name = "Giá")]
        public double Gia { get; set; }
        [StringLength(100)]
        [Display(Name = "Hình")]
        public string Hinh { get; set; }
        [NotMapped]
        [Display(Name = "Chọn hình")]
        public IBrowserFile ImageFile { get; set; }
        [Display(Name = "Số lượt xem")]
        public int Soluotxem { get; set; }
        [Display(Name = "Đặc biệt")]
        public Dacbiet Dacbiet { get; set; }
        [Display(Name = "Ngày nhập"), Required(ErrorMessage = "Bạn cần chọn ngày."), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Ngaynhap { get; set; }
        [Required(ErrorMessage = "Bạn cần nhập giảm giá."), Range(0, double.MaxValue, ErrorMessage = "Bạn cần nhập giảm giá.")]
        [Display(Name = "Giảm Giá")]
        public double Giamgia { get; set; }
        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }
        [Display(Name = "Trạng thái")]
        public TrangthaiSP TrangthaiSP { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }
        public QuanTri QuanTri { get; set; }

    }
}
