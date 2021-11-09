using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Helpers;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IQuanTri
    {
        QuanTri Login(QuanTri quantri);
        List<QuanTri> DanhSachQuanTri();
        bool XoaNguoiQuanTri(int idnguoiquantri, int idqtht);
        Task<bool> SuaNguoiQuanTri(int id, QuanTri quantri);
        Task<QuanTri> GetQuanTri(int id);
        Task<QuanTri> ThemQuanTri(QuanTri quantri);
        bool ExistQuanTri(string username);
    }
    public class QuanTriSvc : IQuanTri
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public QuanTriSvc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public List<QuanTri> DanhSachQuanTri()
        {
            List<QuanTri> list = null;
            list = _context.QuanTris.ToList();
            return list;
        }

        public bool ExistQuanTri(string username)
        {
            QuanTri qt = _context.QuanTris.Where(u => u.Taikhoan == username).FirstOrDefault();
            if (qt != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<QuanTri> GetQuanTri(int id)
        {
            return await _context.QuanTris.FindAsync(id);
        }

        public QuanTri Login(QuanTri quantri)
        {
            var u = _context.QuanTris.Where(
                p => p.Taikhoan.Equals(quantri.Taikhoan)
                && p.Matkhau.Equals(_maHoaHelper.Mahoa(quantri.Matkhau))).FirstOrDefault();
            return u;
        }

        public async Task<bool> SuaNguoiQuanTri(int id, QuanTri quantri)
        {
            QuanTri qt = await GetQuanTri(id);
            if (quantri.Matkhau == "" || quantri.Matkhau =="0") // Khi thay đổi thông tin
            {
                quantri.Matkhau = qt.Matkhau;
                _context.QuanTris.Update(quantri);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                quantri.Matkhau = _maHoaHelper.Mahoa(quantri.Matkhau);// khi đổi mật khẩu
                _context.QuanTris.Update(quantri);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<QuanTri> ThemQuanTri(QuanTri quantri)
        {
            if (ExistQuanTri(quantri.Taikhoan))
            {
                return quantri = null;
            }
            else
            {
                _context.QuanTris.Add(quantri);
                await _context.SaveChangesAsync();
                return quantri;
            }
        }

        public bool XoaNguoiQuanTri(int idnguoiquantri, int idqtht)
        {
            bool ret;
            try
            {
                if (idnguoiquantri != 1 || idnguoiquantri != idqtht)
                {
                    QuanTri quantri = null;
                    quantri = _context.QuanTris.Find(idnguoiquantri);
                    _context.QuanTris.Remove(quantri);
                    _context.SaveChanges();
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }
    }
}
