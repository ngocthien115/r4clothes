using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace R4Clothes.Shared.Services
{
    public interface ISanPham
    {
        List<SanPham> DanhSachSanPhamAdmin();
        List<SanPham> DanhSachSanPham();
        SanPham AddSanPham(SanPham sanPham);
        bool SuaSanPham(int id, SanPham sanPham);
        bool XoaSanPham(int id);
        bool ThongKe();
        List<SanPham> SanPhamLienQuan(int loaiSanPham);
    }
    public class SanPhamSvc : ISanPham
    {
        protected DataContext _context;
        public async Task<SanPham> AddSanPham(SanPham sanPham)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.SanPhams.Add(sanPham);
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }

        public List<SanPham> DanhSachSanPham()
        {
            List<SanPham> list = new List<SanPham>();
            list = _context.SanPhams.Where(t => t.Trangthai == true).ToList();
            return list;
        }

        public List<SanPham> DanhSachSanPhamAdmin()
        {
            List<SanPham> list = new List<SanPham>();
            list = _context.SanPhams.ToList();
            return list;
        }

        public List<SanPham> SanPhamLienQuan(int loaiSanPham)
        {
            List<SanPham> list = new List<SanPham>();
            list = _context.SanPhams.Where(l => l.Maloai == loaiSanPham).ToList();
            return list;
        }

        public bool SuaSanPham(int id, SanPham sanPham)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ThongKe()
        {
            throw new NotImplementedException();
        }

        public bool XoaSanPham(int id)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
