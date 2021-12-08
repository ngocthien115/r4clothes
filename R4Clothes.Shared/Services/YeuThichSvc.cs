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
        Task<YeuThich> ThemYeuThich(YeuThich yeuthich);
        Task<bool> XoaYeuThich(int idsp, int idkh);
        bool CheckYT(int makh, int masp);
    }
    public class YeuThichSvc : IYeuThich
    {
        protected DataContext _context;
        public YeuThichSvc(DataContext context)
        {
            _context = context;
        }

        public bool CheckYT(int makh, int masp)
        {
            bool flag = false;
            List<YeuThich> lsyt = _context.YeuThichs.Where(m => m.Makhachhang == makh).ToList();
            for (int i = 0; i < lsyt.Count; i++)
            {
                if (lsyt[i].Makhachhang == makh && lsyt[i].Masanpham == masp)
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }

        public async Task<YeuThich> ThemYeuThich(YeuThich yeuthich)
        {
            if (CheckYT(yeuthich.Makhachhang, yeuthich.Masanpham))
            {
                return yeuthich;
            }
            else
            {
                _context.YeuThichs.Add(yeuthich);   
                await _context.SaveChangesAsync();
                return yeuthich;
            }
        }

        public async Task<bool> XoaYeuThich(int idsp, int idkh)
        {
            bool flag = false;
            var ls = await _context.YeuThichs.Where(sp => sp.Masanpham == idsp).ToListAsync();
            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Makhachhang == idkh)
                {
                    _context.Remove(ls[i]);
                    await _context.SaveChangesAsync();
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
