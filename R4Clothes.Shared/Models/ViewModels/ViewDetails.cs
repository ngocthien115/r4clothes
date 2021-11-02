using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models.ViewModels
{
    public class ViewDetails
    {
        public HoaDon hoadon { get; set; }
        public SanPham sanpham { get; set; }
        public ChiTietHoaDon chitiethoadon { get; set; }
    }
}
