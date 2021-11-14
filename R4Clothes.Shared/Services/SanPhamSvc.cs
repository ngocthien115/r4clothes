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
        SanPham GetSanPham(int id);
        List<SanPham> LoadYeuThich(int idkh);
        List<SanPham> DanhSachSanPhamAdmin();
        List<SanPham> DanhSachSanPham();
        Task<SanPham> AddSanPham(SanPham sanPham);
        Task<bool> SuaSanPham(int id, SanPham sanPham);
        Task<bool> XoaSanPham(int id);
        bool GiamSL(int idsp, int sl);
        List<SanPham> SanPhamLienQuan(int loaiSanPham);
        List<SanPham> SanPhamDacBiet();
        List<SanPham> SanPhamGiamGia(int giamgia);

    }
    public class SanPhamSvc : ISanPham
    {
        protected DataContext _context;
        public SanPhamSvc(DataContext context)
        {
            _context = context;
        }

        public SanPham GetSanPham(int id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp != null)
            {
                sp.Soluotxem += 1;
                return sp;
            }
            else
            {
                return sp = null;
            }
            
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

        public List<SanPham> SanPhamGiamGia(int giamgia)
        {
            List<SanPham> list = new List<SanPham>();
            
            if (giamgia != 0)
            {
                list = _context.SanPhams.Where(g => g.Giamgia == giamgia).ToList();
            }
            else
            {
                list = _context.SanPhams.Where(g => g.Giamgia > 0).ToList();
            }
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
        public bool GiamSL(int idsp, int sl)
        {
            SanPham sp = _context.SanPhams.Find(idsp);
            sp.Soluong -= sl;
            _context.SaveChanges();
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
