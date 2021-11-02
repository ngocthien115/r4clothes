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
        bool AddDanhGiaSanPham(DanhGiaSanPham danhGiaSanPham);
        List<DanhGiaSanPham> XemDanhGiaTheoSanPham(int idsanpham);
    }
    public class DanhGiaSanPhamSvc : IDanhGiaSanPham
    {
        public DataContext _context;
        public DanhGiaSanPhamSvc(DataContext context)
        {
            _context = context;
        }
        public bool AddDanhGiaSanPham(DanhGiaSanPham danhGiaSanPham)
        {
            bool ret;
            try
            {
                _context.Add(danhGiaSanPham);
                _context.SaveChanges();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public List<DanhGiaSanPham> XemDanhGiaTheoSanPham(int idsanpham)
        {
            List<DanhGiaSanPham> list = new List<DanhGiaSanPham>();
            list = _context.DanhGiaSanPhams.Where(x => x.Masanpham == idsanpham).OrderByDescending(x => x.Thoigian)
                .Include(x => x.SanPham)
                .ToList();           
            return list;
        }
    }
}
