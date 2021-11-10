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
    public interface IKhachHang
    {
        KhachHang Login(LoginKH loginKH);
        Task<bool> QuenMatKhau(string emailkh);
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
        protected ISendMailHelper _sendmail;
        protected IRandomStringHelper _randomString;

        public KhachHangSvc(DataContext context, IMaHoaHelper mahoa, ISendMailHelper sendmail, IRandomStringHelper randomString)
        {
            _context = context;
            _mahoa = mahoa;
            _sendmail = sendmail;
            _randomString = randomString;
        }

        public async Task<KhachHang> AddKhachhang(KhachHang khachhang)
        {
            try
            {
                khachhang.Makhachhang = 0;
                khachhang.Matkhau = _mahoa.Mahoa(khachhang.Matkhau);
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return khachhang;
            }
            catch (Exception)
            {
                return khachhang = null;
            }
            
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
            var a = _mahoa.Mahoa(oldpwd);
            if (_mahoa.Mahoa(oldpwd) == kh.Matkhau)
            {
                kh.Matkhau = _mahoa.Mahoa(newpwd);
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

        public KhachHang Login(LoginKH loginKH)
        {
            var u = _context.KhachHangs.Where(
                p => p.Email.Equals(loginKH.Email)
                && p.Matkhau.Equals(_mahoa.Mahoa(loginKH.Password))
               ).FirstOrDefault();
            return u;
        }

        public async Task<bool> QuenMatKhau(string email)
        {
            try
            {
                string newpwd = _randomString.RandomString().ToLower();
                if (isExist(email))
                {
                    KhachHang kh = _context.KhachHangs.Where(e => e.Email == email).FirstOrDefault();
                    var body = "Mật khẩu mới để đăng nhập R4 Clothes của bạn là : " + newpwd;
                    var subject = "Mật khẩu tài khoản R4 Clothes của bạn đã được reset";
                    _sendmail.SendMail(email, body, subject);

                    kh.Matkhau = _mahoa.Mahoa(newpwd);
                    _context.KhachHangs.Update(kh);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<KhachHang> SuaKhachhang(int id, KhachHang khachhang)
        {
            try
            {
                KhachHang kh = await GetKhachhang(id);
                kh.Email = khachhang.Email;
                kh.Diachi = khachhang.Diachi;
                kh.Gioitinh = khachhang.Gioitinh;
                kh.Ngaysinh = khachhang.Ngaysinh;
                kh.Hinh = khachhang.Hinh;
                kh.Tenkhachhang = khachhang.Tenkhachhang;

                _context.Entry(kh).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return khachhang;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return khachhang = null;
            }
        }

        public bool XoaKhachHang(int id)
        {
            KhachHang kh = _context.KhachHangs.Find(id);
            if (kh != null && kh.Trangthai == false)
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
