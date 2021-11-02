using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
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
        Task<SanPham> AddSanPham(SanPham sanPham);
        Task<bool> SuaSanPham(int id, SanPham sanPham);
        Task<bool> XoaSanPham(int id);
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
                return sanPham;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return sanPham = null;
            }
        }

        public List<SanPham> DanhSachSanPham()
        {
            throw new NotImplementedException();
            //List<SanPham> list = new List<SanPham>();
            //list = _context.SanPhams.Where(t => t.Trangthai == true).ToList();
            //return list;
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

        public async Task<bool> SuaSanPham(int id, SanPham sanPham)
        {
            if (id != sanPham.Masanpham)
            {
                return false;
            }

            _context.Entry(sanPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public bool ThongKe()
        {
            return true;
        }

        public async Task<bool> XoaSanPham(int id)
        {
            try
            {
                var sanPham = await _context.SanPhams.FindAsync(id);
                if (sanPham == null)
                {
                    return false;
                }

                _context.SanPhams.Remove(sanPham);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
