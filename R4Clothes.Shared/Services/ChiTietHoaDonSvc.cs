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
        List<SanPhamCT> GetChiTiet(int maHoaDon);

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

        public List<SanPhamCT> GetChiTiet(int id)
        {
            List<SanPham> sanpham = _context.SanPhams.ToList();
            List<ChiTietHoaDon> chitiet = _context.ChiTietHoaDons.Where(c => c.Mahoadon == id).ToList();

            List<SanPhamCT> danhsach = (from sp in sanpham
                                      join ct in chitiet
                                      on sp.Masanpham equals ct.Masanpham
                                      where ct.Mahoadon == id
                                      select new SanPhamCT 
                                      { 
                                          TenSanPham = sp.Tensanpham,
                                          Gia = sp.Gia,
                                          Hinh = sp.Hinh,
                                          SoLuongMua = ct.Soluong
                                      }).ToList();
            return danhsach;
        }
    }
}
