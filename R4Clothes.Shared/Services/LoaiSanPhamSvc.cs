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
        public DataContext _context;
        public LoaiSanPhamSvc(DataContext context)
        {
            _context = context;
        }
        public bool AddLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            bool ret;
            try
            {
                loaiSanPham.Maloai = 0;
                _context.LoaiSanPhams.Add(loaiSanPham);
                _context.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<LoaiSanPham> DanhSachLoaiSanPham()
        {
            return _context.LoaiSanPhams.ToList();
        }

        public bool XoaLoaiSanPham(int idloaisanpham)
        {
            bool ret;
            try
            {
                var loaiSp = _context.LoaiSanPhams.Find(idloaisanpham);
                _context.LoaiSanPhams.Remove(loaiSp);
                _context.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}
