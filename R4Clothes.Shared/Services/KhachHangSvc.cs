using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    interface IKhachHang
    {
        KhachHang Login();//WebViewLogin
        bool QuenMatKhau(int idkhachhang, string oldpwd, string newpwd);
        List<KhachHang> DanhSachKhachHang();
        KhachHang GetKhachhang(int id);
        KhachHang AddKhachhang(KhachHang khachhang);
        KhachHang SuaKhachhang(int id, KhachHang khachhang);
        bool XoaKhachHang(int id);
    }
    public class KhachHangSvc : IKhachHang
    {
        public KhachHang AddKhachhang(KhachHang khachhang)
        {
            throw new NotImplementedException();
        }

        public List<KhachHang> DanhSachKhachHang()
        {
            throw new NotImplementedException();
        }

        public KhachHang GetKhachhang(int id)
        {
            throw new NotImplementedException();
        }

        public KhachHang Login()
        {
            throw new NotImplementedException();
        }

        public bool QuenMatKhau(int idkhachhang, string oldpwd, string newpwd)
        {
            throw new NotImplementedException();
        }

        public KhachHang SuaKhachhang(int id, KhachHang khachhang)
        {
            throw new NotImplementedException();
        }

        public bool XoaKhachHang(int id)
        {
            throw new NotImplementedException();
        }
    }
}
