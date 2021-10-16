using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    interface ISanPham
    {
        List<SanPham> DanhSachSanPhamAdmin();
        List<SanPham> DanhSachSanPham();
        SanPham AddSanPham(SanPham sanPham);
        bool SuaSanPham(int id, SanPham sanPham);
        bool XoaSanPham(int id);
        bool ThongKe();
        List<SanPham> SanPhamLienQuan(string loaiSanPham);
    }
    public class SanPhamSvc : ISanPham
    {
        public SanPham AddSanPham(SanPham sanPham)
        {
            throw new NotImplementedException();
        }

        public List<SanPham> DanhSachSanPham()
        {
            throw new NotImplementedException();
        }

        public List<SanPham> DanhSachSanPhamAdmin()
        {
            throw new NotImplementedException();
        }

        public List<SanPham> SanPhamLienQuan(string loaiSanPham)
        {
            throw new NotImplementedException();
        }

        public bool SuaSanPham(int id, SanPham sanPham)
        {
            throw new NotImplementedException();
        }

        public bool ThongKe()
        {
            throw new NotImplementedException();
        }

        public bool XoaSanPham(int id)
        {
            throw new NotImplementedException();
        }
    }
}
