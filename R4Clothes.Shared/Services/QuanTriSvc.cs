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
        QuanTri Login(ViewLogin viewLogin);
        List<QuanTri> DanhSachQuanTri();
        bool XoaNguoiQuanTri(int idnguoiquantri);
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
            List<QuanTri> list = new List<QuanTri>();
            list = _context.QuanTris.ToList();
            return list;
        }

        public QuanTri Login(ViewLogin viewLogin)
        {
            var u = _context.QuanTris.Where(
                p => p.Taikhoan.Equals(viewLogin.UserName)
                && p.Matkhau.Equals(_maHoaHelper.Mahoa(viewLogin.Password))).FirstOrDefault();
            return u;
        }

        public bool XoaNguoiQuanTri(int idnguoiquantri)
        {
            bool ret;
            try
            {
                QuanTri quantri = null;
                quantri = _context.QuanTris.Find(idnguoiquantri);
                _context.QuanTris.Remove(quantri);
                _context.SaveChanges();
                ret = true;
            }
            catch (Exception)
            {
                ret = false;
            }
            
            return ret;
        }
    }
}
