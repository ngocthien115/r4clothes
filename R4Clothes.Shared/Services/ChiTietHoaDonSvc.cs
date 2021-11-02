using R4Clothes.Shared.Models;
using R4Clothes.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IChiTietHoaDon
    {
        bool AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);
        List<ViewDetails> GetChiTiet(int maHoaDon); // list ViewDetails

    }
    public class ChiTietHoaDonSvc : IChiTietHoaDon
    {
        protected DataContext _context;
        public ChiTietHoaDonSvc(DataContext context)
        {
            _context = context;
        }
        public bool AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                _context.Add(chiTietHoaDon);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ViewDetails> GetChiTiet(int id)
        {
            List<SanPham> sanpham = _context.SanPhams.ToList();
            List<HoaDon> hoadon = _context.HoaDons.ToList();
            List<ChiTietHoaDon> chitiethoadon = _context.ChiTietHoaDons.ToList();

            List<ViewDetails> danhsach = (from sp in sanpham
                                          join ct in chitiethoadon on sp.Masanpham equals ct.Masanpham into table1
                                          from ct in table1.ToList()
                                          join hd in hoadon on ct.Mahoadon equals hd.Mahoadon into table2
                                          from hd in table2.ToList()
                                          where ct.Mahoadon == id
                                          select new ViewDetails
                                          {
                                              hoadon = hd,
                                              sanpham = sp,
                                              chitiethoadon = ct
                                          }).ToList();
            return danhsach;
        }
    }
}
