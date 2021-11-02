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
    public interface IKhachHang
    {
        KhachHang Login(string email, string matkhau);//WebViewLogin
        bool QuenMatKhau(string emailkh);
        Task<bool> DoiMatKhau(int idkhachhang, string oldpwd, string newpwd);
        Task<List<KhachHang>> DanhSachKhachHang();
        Task<KhachHang> GetKhachhang(int id);
        Task<KhachHang> AddKhachhang(KhachHang khachhang);
        Task<KhachHang> SuaKhachhang(int id, KhachHang khachhang);
        bool XoaKhachHang(int id);
        bool isExist(string email);
    }
    public class KhachHangSvc : IKhachHang
    {
        protected DataContext _context;
        protected IMaHoaHelper _mahoa;
        public KhachHangSvc(DataContext context, IMaHoaHelper mahoa)
        {
            _context = context;
            _mahoa = mahoa;
        }
        public async Task<KhachHang> AddKhachhang(KhachHang khachhang)
        {
            _context.Add(khachhang);
            await _context.SaveChangesAsync();
            return khachhang;
        }

        public async Task<List<KhachHang>> DanhSachKhachHang()
        {
            List<KhachHang> ls = null;
            ls = await _context.KhachHangs.ToListAsync();
            return ls;
        }

        public async Task<bool> DoiMatKhau(int idkhachhang, string oldpwd, string newpwd)
        {
            KhachHang kh = _context.KhachHangs.Find(idkhachhang);
            if (oldpwd == kh.Matkhau)
            {
                kh.Matkhau = newpwd;
                _context.Update(kh);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<KhachHang> GetKhachhang(int id)
        {
            KhachHang khachhang = null;
            khachhang = await _context.KhachHangs.FindAsync(id);
            return khachhang;
        }

        public bool isExist(string email)
        {
            var kh = _context.KhachHangs.Where(e => e.Email == email);
            if (kh != null)
            {
                return true;
            }
            else
                return false;
        }

        public KhachHang Login(string email, string matkhau)
        {
            var u = _context.KhachHangs.Where(
                p => p.Email.Equals(email)
                && p.Matkhau.Equals(_mahoa.Mahoa(matkhau))
               ).FirstOrDefault();
            return u;
        }

        public bool QuenMatKhau(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<KhachHang> SuaKhachhang(int id, KhachHang khachhang)
        {
            KhachHang kh_old = await _context.KhachHangs.FindAsync(id);
            if (khachhang != null)
            {
                khachhang.Matkhau = kh_old.Matkhau;
                _context.Update(khachhang);
                await _context.SaveChangesAsync();
                return khachhang;
            }
            else
                return khachhang = null;
        }

        public bool XoaKhachHang(int id)
        {
            KhachHang kh = _context.KhachHangs.Find(id);
            if (kh != null)
            {
                _context.Remove(kh);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
