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
        bool SuaHoaDon(int iddonhang, int idquanly, TrangthaiHD tt);
        HoaDon GetHoaDon(int id);
        List<HoaDon> DanhSachHoaDonStatus(TrangthaiHD tt);
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
            list = _context.HoaDons.OrderByDescending(x => x.Ngaydat).ToList();
            return list;
        }

        public List<HoaDon> DanhSachHoaDonTheoKhachHang(int idnguoidung)
        {
            List<HoaDon> list = new List<HoaDon>();
            // sử dụng kỹ thuật loading Eager // từ khóa Include
            list = _context.HoaDons.Where(h => h.Makhachhang == idnguoidung).ToList();
            return list;
        }

        public HoaDon GetHoaDon(int id)
        {
            HoaDon hoadon = null;
            hoadon = _context.HoaDons.Where(e=>e.Mahoadon == id).FirstOrDefault(); //cách tổng quát
            return hoadon;
        }

        public bool SuaHoaDon(int idhoadon, int idquanly, TrangthaiHD tt)
        {
            HoaDon hd = GetHoaDon(idhoadon);
            if (hd == null)
            {
                return false;
            }
            else
            {
                try
                {
                    hd.Nguoiquantri = idquanly;
                    hd.Trangthai = tt;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public List<HoaDon> DanhSachHoaDonStatus(TrangthaiHD tt) 
        {
            return _context.HoaDons.Where(t => t.Trangthai == tt).ToList();
        }
    }
}
