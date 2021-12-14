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
    public interface IDanhGiaSanPham
    {
        Task<DanhGiaSanPham> AddDanhGiaSanPham(DanhGiaSanPham danhgia);
        Task<List<DanhGiaSanPhamReturn>> DanhGiaSanPhamTheoIDSP(int idsp);
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

        public async Task<List<DanhGiaSanPhamReturn>> DanhGiaSanPhamTheoIDSP(int idsp)
        {
            List<DanhGiaSanPhamReturn> danhgiasanphamrt = new List<DanhGiaSanPhamReturn>();
            danhgiasanphamrt = (from dgsp in _context.DanhGiaSanPhams.ToList()
                                join kh in _context.KhachHangs.ToList()
                                on dgsp.Makhachhang equals kh.Makhachhang
                                where dgsp.Masanpham == idsp
                                select new DanhGiaSanPhamReturn
                                {
                                    MaKhachHang = dgsp.Makhachhang,
                                    Tenkhachhang = kh.Tenkhachhang,
                                    Hinh = kh.Hinh,
                                    Thoigian = dgsp.Thoigian,
                                    NoiDung = dgsp.Noidung
                                }).ToList();
            return danhgiasanphamrt;
        }
    }
}
