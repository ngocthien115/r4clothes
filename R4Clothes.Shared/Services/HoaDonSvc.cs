using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    interface IHoaDon
    {
        bool AddHoaDon(HoaDon hoadon);
        List<HoaDon> DanhSachHoaDonTheoKhachHang(int idnguoidung);
        List<HoaDon> DanhSachHoaDon();
        bool SuaDonHang(int iddonhang);
    }
    public class HoaDonSvc : IHoaDon
    {
        public bool AddHoaDon(HoaDon hoadon)
        {
            throw new NotImplementedException();
        }

        public List<HoaDon> DanhSachHoaDon()
        {
            throw new NotImplementedException();
        }

        public List<HoaDon> DanhSachHoaDonTheoKhachHang(int idnguoidung)
        {
            throw new NotImplementedException();
        }

        public bool SuaDonHang(int iddonhang)
        {
            throw new NotImplementedException();
        }
    }
}
