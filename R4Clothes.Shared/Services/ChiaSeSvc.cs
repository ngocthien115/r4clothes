using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IChiaSe
    {
        Task<List<ChiaSe>> DSCS();
        Task<bool> ThemChiaSe(ChiaSe chiase);
    }
    public class ChiaSeSvc : IChiaSe
    {
        protected DataContext _context;
        public ChiaSeSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ChiaSe>> DSCS()
        {
            return await _context.ChiaSes.ToListAsync();
        }

        public async Task<bool> ThemChiaSe(ChiaSe chiase)
        {
            if (chiase.EmailNguoiNhan != null || chiase.MaKhachHang != null || chiase.MaSanPham != null)
            {
                _context.ChiaSes.Add(chiase);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}
