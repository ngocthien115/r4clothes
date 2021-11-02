using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IHoaDon
    {
        int AddHoaDon(HoaDon hoadon);
        List<HoaDon> DanhSachHoaDonTheoKhachHang(int idnguoidung);
        List<HoaDon> DanhSachHoaDon();
        bool SuaHoaDon(int iddonhang, HoaDon hoadon);
        HoaDon GetHoaDon(int id);
    }
    public class HoaDonSvc : IHoaDon
    {
        protected DataContext _context;
        public HoaDonSvc(DataContext context)
        {
            _context = context;
        }
        public int AddHoaDon(HoaDon hoadon)
        {
            int ret = 0;
            try
            {
                _context.Add(hoadon);
                _context.SaveChanges();
                ret = hoadon.Mahoadon;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public List<HoaDon> DanhSachHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();
            // sử dụng kỹ thuật loading Eager // từ khóa Include
            list = _context.HoaDons.OrderByDescending(x => x.Ngaydat)
                .Include(x => x.KhachHang)
                .Include(x => x.ChiTietHoaDons)
                .ToList();
            return list;
        }

        public List<HoaDon> DanhSachHoaDonTheoKhachHang(int idnguoidung)
        {
            List<HoaDon> list = new List<HoaDon>();
            // sử dụng kỹ thuật loading Eager // từ khóa Include
            list = _context.HoaDons.Where(x => x.Makhachhang == idnguoidung).OrderByDescending(x => x.Ngaydat)
                .Include(x => x.KhachHang)
                .Include(x => x.ChiTietHoaDons)
                .ToList();
            return list;
        }

        public HoaDon GetHoaDon(int id)
        {
            HoaDon hoadon = null;
            hoadon = _context.HoaDons.Where(x => x.Mahoadon == id)
                .Include(x => x.KhachHang)
                .Include(x => x.ChiTietHoaDons).ThenInclude(y => y.SanPham)
                .FirstOrDefault();
            //product = _context.Products.Where(e=>e.Id==id).FirstOrDefault(); //cách tổng quát
            return hoadon;
        }

        public bool SuaHoaDon(int idhoadon, HoaDon hoadon)
        {
            HoaDon hd = _context.HoaDons.Find(idhoadon);
            if (hd == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _context.Update(hoadon);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
