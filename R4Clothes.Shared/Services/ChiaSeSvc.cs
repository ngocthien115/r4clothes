using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using R4Clothes.Shared.Helpers;

namespace R4Clothes.Shared.Services
{
    public interface IChiaSe
    {
        bool AddChiaSe(ChiaSe chiaSe);
    }
    public class ChiaSeSvc : IChiaSe
    {
        protected DataContext _context;
        protected ISendMailHelper _sendmail;

        public ChiaSeSvc(DataContext context, ISendMailHelper sendmail)
        {
            _context = context;
            _sendmail = sendmail;
        }

        public bool AddChiaSe(ChiaSe chiaSe)
        {
            var khachHang = _context.KhachHangs.Find(chiaSe.MaKhachHang);
            var sanpham = _context.SanPhams.Find(chiaSe.MaSanPham);
            bool ret;
            try
            {
                var subject = "Có người đề xuất món đồ đến cho bạn !";
                var body = "Chào " + chiaSe.EmailNguoiNhan + ", một người bạn của bạn tên " + khachHang.Tenkhachhang + " đã đề xuất " + sanpham.Tensanpham + " với bạn. " +
                    "Truy cập vào link bên dưới để có thêm thông tin. " + chiaSe.LinkSP;
                _sendmail.SendMail(chiaSe.EmailNguoiNhan, body, subject);
                _context.ChiaSes.Add(chiaSe);
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
