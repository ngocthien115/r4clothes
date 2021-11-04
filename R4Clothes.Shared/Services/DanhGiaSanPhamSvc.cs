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
        bool AddDanhGiaSanPham(int idsanpham, DanhGiaSanPham danhgia);
        List<DanhGiaSanPham> XemDanhGiaSanPham(int idsanpham);
    }
    public class DanhGiaSanPhamSvc : IDanhGiaSanPham
    {
        public DataContext _context;
        public DanhGiaSanPhamSvc(DataContext context)
        {
            _context = context;
        }
        public bool AddDanhGiaSanPham(int idsanpham, DanhGiaSanPham danhgia)
        {
            bool ret;
            try
            {
                danhgia.Masanpham = idsanpham;
                _context.Add(danhgia);
                _context.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<DanhGiaSanPham> XemDanhGiaSanPham(int idsanpham)
        {
            List<DanhGiaSanPham> list = new List<DanhGiaSanPham>();
            list = _context.DanhGiaSanPhams.Where(x => x.Masanpham == idsanpham).OrderByDescending(x => x.Thoigian)
                .Include(x => x.SanPham)
                .ToList();
            return list;
        }
    }
}
