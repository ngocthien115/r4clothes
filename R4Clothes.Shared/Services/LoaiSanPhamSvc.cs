using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface ILoaiSanPham
    {
        Task<LoaiSanPham> AddLoaiSanPham(LoaiSanPham loaiSanPham);
        Task<List<LoaiSanPham>> DanhSachLoaiSanPham();
    }
    public class LoaiSanPhamSvc : ILoaiSanPham
    {
        public DataContext _context;
        public LoaiSanPhamSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<LoaiSanPham> AddLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            loaiSanPham.Maloai = 0;
            _context.Add(loaiSanPham);
            await _context.SaveChangesAsync();
            return loaiSanPham;
        }

        public async Task<List<LoaiSanPham>> DanhSachLoaiSanPham()
        {
            return await _context.LoaiSanPhams.ToListAsync();
        }
    }
}
