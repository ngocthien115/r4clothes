using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    interface ILoaiSanPham
    {
        bool AddLoaiSanPham(LoaiSanPham loaiSanPham);
        List<LoaiSanPham> DanhSachLoaiSanPham();
        bool XoaLoaiSanPham(int idloaisanpham);
    }
    public class LoaiSanPhamSvc : ILoaiSanPham
    {
        public bool AddLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            throw new NotImplementedException();
        }

        public List<LoaiSanPham> DanhSachLoaiSanPham()
        {
            throw new NotImplementedException();
        }

        public bool XoaLoaiSanPham(int idloaisanpham)
        {
            throw new NotImplementedException();
        }
    }
}
