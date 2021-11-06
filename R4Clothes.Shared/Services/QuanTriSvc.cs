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
        Task<List<QuanTri>> DanhSachQuanTri();
        bool XoaNguoiQuanTri(int idnguoiquantri, int idqtht);
        bool SuaNguoiQuanTri(int id, QuanTri quantri);
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
        public async Task<List<QuanTri>> DanhSachQuanTri()
        {
            List<QuanTri> list = new List<QuanTri>();
            list = await _context.QuanTris.ToListAsync();
            return list;
        }

        public QuanTri Login(Login login)
        {
            var u = _context.QuanTris.Where(
                p => p.Taikhoan.Equals(login.User)
                && p.Matkhau.Equals(_maHoaHelper.Mahoa(login.Password))).FirstOrDefault();
            return u;
        }

        public bool SuaNguoiQuanTri(int id, QuanTri quantri)
        {
            quantri.Matkhau = _maHoaHelper.Mahoa(quantri.Matkhau);
            _context.QuanTris.Update(quantri);
            _context.SaveChanges();
            return true;
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
