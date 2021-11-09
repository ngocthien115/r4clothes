using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IDanhGiaSanPham
    {
        Task<DanhGiaSanPham> AddDanhGiaSanPham(DanhGiaSanPham danhgia);
        Task<List<DanhGiaSanPham>> DanhGiaSanPhamTheoIDSP(int idsp);
    }
    public class DanhGiaSanPhamSvc : IDanhGiaSanPham
    {
        public DataContext _context;
        public DanhGiaSanPhamSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<DanhGiaSanPham> AddDanhGiaSanPham(DanhGiaSanPham danhgia)
        {
            _context.Add(danhgia);
            await _context.SaveChangesAsync();
            return danhgia;
        }

        public async Task<List<DanhGiaSanPham>> DanhGiaSanPhamTheoIDSP(int idsp)
        {
            List<DanhGiaSanPham> danhgiasanpham = new List<DanhGiaSanPham>();
            danhgiasanpham = await _context.DanhGiaSanPhams.Where(t => t.Masanpham == idsp).ToListAsync();
            return danhgiasanpham;
        }
    }
}
