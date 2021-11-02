using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IYeuThich
    {
        Task<List<YeuThich>> DanhSachYeuThichTheoID(int id);
        Task<YeuThich> ThemYeuThich(YeuThich yeuthich);
        Task<bool> XoaYeuThich(int id);
    }
    public class YeuThichSvc : IYeuThich
    {
        protected DataContext _context;
        public YeuThichSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<List<YeuThich>> DanhSachYeuThichTheoID(int id)
        {
            List<YeuThich> ls = new List<YeuThich>();
            ls = await _context.YeuThichs.Where(t => t.Makhachhang == id).ToListAsync();
            return ls;
        }

        public async Task<YeuThich> ThemYeuThich(YeuThich yeuthich)
        {
            _context.YeuThichs.Add(yeuthich);
            await _context.SaveChangesAsync();
            return yeuthich;
        }

        public async Task<bool> XoaYeuThich(int id)
        {
            YeuThich yt = new YeuThich();
            yt = _context.YeuThichs.Find(id);
            if (yt != null)
            {
                _context.Remove(id);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}
