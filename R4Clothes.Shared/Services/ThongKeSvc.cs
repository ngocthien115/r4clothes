using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IThongKe
    {
        List<SanPham> SoLuongSanPhamBanDuoc();
        Task<List<HoaDon>> DoanhThu(DateTime from, DateTime to);
        List<KhachHangTT> KhachHangThanThiet();

    }
    public class ThongKeSvc:IThongKe
    {
        protected DataContext _context;
        protected ISanPham _sanphamSvc;
        protected IKhachHang _khachhangSvc;
        protected IHoaDon _hoadonSvc;
        protected IChiTietHoaDon _chitietSvc;
        public ThongKeSvc(DataContext context, ISanPham sanphamSvc, IKhachHang khachhangSvc, IHoaDon hoadonSvc, IChiTietHoaDon chitietSvc)
        {
            _context = context;
            _sanphamSvc = sanphamSvc;
            _khachhangSvc = khachhangSvc;
            _hoadonSvc = hoadonSvc;
            _chitietSvc = chitietSvc;
        }

        public async Task<List<HoaDon>> DoanhThu(DateTime from, DateTime to)
        {
            List<HoaDon> hd = null;
            if (from ==  null|| to == null)
            {
                hd = _hoadonSvc.DanhSachHoaDon();
                return hd;
            }
            else
            {
                hd = await _context.HoaDons.Where(d => d.Ngaydat.Date >= from && d.Ngaydat.Date <= to).ToListAsync();
                return hd;
            }
        }

        public List<KhachHangTT> KhachHangThanThiet()
        {
            List<KhachHangTT> ls = (from kh in _context.KhachHangs
                              join dh in from dh in _context.HoaDons
                                         group dh by dh.Makhachhang into g
                                         select new { CusID = g.Key, SoLuongDH = g.Count() }
                              on kh.Makhachhang equals dh.CusID
                              select new KhachHangTT { TenKhachHang = kh.Tenkhachhang, EmailKhachHang = kh.Email, SDT = kh.Sodienthoai, SoHoaDon = dh.SoLuongDH }).ToList();
            return ls;
        }

        public List<SanPham> SoLuongSanPhamBanDuoc()
        {
            var ls = (from ma in _context.SanPhams
                      join ts in from ct in _context.ChiTietHoaDons
                                 group ct by ct.Masanpham into g
                                 select new
                                 {
                                     monanid = g.Key,
                                     tongsomon = g.Sum(e => e.Soluong)
                                 }
                      on ma.Masanpham equals ts.monanid
                      select new SanPham
                      {
                          Tensanpham = ma.Tensanpham,
                          Gia = ma.Gia,
                          LoaiSanPhams = ma.LoaiSanPhams,
                          Soluong = ts.tongsomon
                      }).ToList();
            return ls;
        }
    }
}
