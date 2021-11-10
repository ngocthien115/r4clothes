using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Helpers;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IQuanTri
    {
        QuanTri Login(Login login);
        List<QuanTri> DanhSachQuanTri();
        bool XoaNguoiQuanTri(int idnguoiquantri, int idqtht);
        Task<bool> SuaNguoiQuanTri(int id, QuanTri quantri);
        bool DoiMatKhau(int id, string newpwd);
        QuanTri GetQuanTri(int id);
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

        public QuanTri GetQuanTri(int id)
        {
            return _context.QuanTris.Find(id);
        }

        public QuanTri Login(Login login)
        {
            var u = _context.QuanTris.Where(
                p => p.Taikhoan.Equals(login.User)
                && p.Matkhau.Equals(_maHoaHelper.Mahoa(login.Password))).FirstOrDefault();
            return u;
        }

        public async Task<bool> SuaNguoiQuanTri(int id, QuanTri quantri)
        {
            try
            {
                QuanTri qt = _context.QuanTris.Find(id);
                if (qt != null)
                {
                    qt.Maquantri = id;
                    qt.Hoten = quantri.Hoten;
                    qt.Taikhoan = quantri.Taikhoan;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DoiMatKhau(int id, string newpwd)
        {
            try
            {
                QuanTri qt = _context.QuanTris.Find(id);
                qt.Matkhau = _maHoaHelper.Mahoa(newpwd);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
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
                quantri.Maquantri = 0;
                quantri.Matkhau = _maHoaHelper.Mahoa(quantri.Matkhau);
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
