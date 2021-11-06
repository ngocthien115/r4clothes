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
        public List<QuanTri> DanhSachQuanTri()
        {
            List<QuanTri> list = new List<QuanTri>();
            list = _context.QuanTris.ToList();
            return list;
        }

        public QuanTri Login(QuanTri quantri)
        {
            var u = _context.QuanTris.Where(
                p => p.Taikhoan.Equals(quantri.Taikhoan)
                && p.Matkhau.Equals(_maHoaHelper.Mahoa(quantri.Matkhau))).FirstOrDefault();
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
