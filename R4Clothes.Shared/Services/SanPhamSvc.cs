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
        List<SanPham> LoadYeuThich(int idkh);
        List<SanPham> DanhSachSanPhamAdmin();
        List<SanPham> DanhSachSanPham();
        Task<SanPham> AddSanPham(SanPham sanPham);
        Task<bool> SuaSanPham(int id, SanPham sanPham);
        Task<bool> XoaSanPham(int id);

        Task<bool> DoiTrangThaiSanPham(int idsp, SanPham sp);

        List<SanPham> SanPhamLienQuan(int loaiSanPham);
        List<SanPham> SanPhamDacBiet();
        List<SanPham> SanPhamGiamGia();

    }
    public class SanPhamSvc : ISanPham
    {
        protected DataContext _context;

        public SanPhamSvc(DataContext context)
        {
            _context = context;
        }

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
            List<SanPham> list = null;
            list = _context.SanPhams.Where(t => t.Trangthai == true).ToList();
            return list;
        }

        public List<SanPham> DanhSachSanPhamAdmin()
        {
            List<SanPham> list = new List<SanPham>();
            list = _context.SanPhams.ToList();
            return list;
        }

        public List<SanPham> SanPhamDacBiet()
        {
            List<SanPham> list = new List<SanPham>();
            list = _context.SanPhams.Where(l => l.Dacbiet == true).ToList();
            return list;
        }

        public List<SanPham> SanPhamGiamGia()
        {
            List<SanPham> list = new List<SanPham>();
            list = _context.SanPhams.Where(l => l.Giamgia != 0 || l.Giamgia != null).ToList();
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

        public async Task<bool> DoiTrangThaiSanPham(int id, SanPham sanPham)
        {
            SanPham sp = null;
            sp = await _context.SanPhams.FindAsync(id);
            if (sp != null && sanPham != null)
            {
                sp.Trangthai = sanPham.Trangthai;
                _context.Update(sp);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
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

        public List<SanPham> LoadYeuThich(int idkh)
        {
            var yeuthich = _context.YeuThichs.ToList();
            var sanpham = _context.SanPhams.ToList();

            var ls = (from y in yeuthich
                      join s in sanpham
                      on y.Masanpham equals s.Masanpham
                      where y.Makhachhang == idkh
                      select s).ToList();
            return ls;
        }
    }
}
