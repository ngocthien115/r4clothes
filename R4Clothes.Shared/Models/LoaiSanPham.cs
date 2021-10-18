using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int Maloai { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Bạn cần nhập tên.")]
        [Display(Name = "Tên loại")]
        public string Tenloai { get; set; }
    }
}
