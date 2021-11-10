using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Models.ViewModels
{
    public class Cart
    {
        public int Makhachhang { get; set; }
        public List<CartItem> ListViewCart { get; set; } = new List<CartItem>();
        public double Tongtien { get; set; }
    }

    public class CartItem
    {
        public SanPham SanPham { get; set; }
        public int Soluong { get; set; }
    }
    public class ViewCart
    {
        public SanPham SanPham { get; set; }
        public int Trangthai { get; set; }
    }
}
