﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models
{
    public class ChiaSe
    {
        [Key]
        public int MaChiaSe { get; set; }
        
        [ForeignKey("KhachHang")]
        public int MaKhachHang { get; set; }
        [Required]
        public string EmailNguoiNhan { get; set; }

        [ForeignKey("SanPham")]
        public int MaSanPham { get; set; }
        [Required]
        public string HoTen { get; set; }

        public KhachHang KhachHang { get; set; }
        public SanPham SanPham { get; set; }
    }
}
