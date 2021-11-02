using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IChiSe
    {
        bool AddChiSe(ChiaSe chiaSe);
    }
    public class ChiaSeSvc : IChiaSe
    {
        protected DataContext _context;
        public ChiaSeSvc(DataContext context)
        {
            _context = context;
        }
        public bool AddChiSe(ChiaSe chiaSe)
        {
            bool ret;
            try
            {
                //  NetworkCredential cred = new NetworkCredential("driverhuyhoa@gmail.com","01635592943");
                MailMessage Msg = new MailMessage();               
                //sender email address
                Msg.From = new MailAddress("phamhuyhoalk20@gmail.com");
                //Recipient e-mail address
                Msg.To.Add(chiaSe.Email);
                //Assign the subject  of out message
                Msg.Subject = "Bạn đã sử dụng tính năng chia sẻ";
                Msg.Body = "Chào " + chiaSe.Hoten + "! " + chiaSe.Makhachhang + " đã chia sẻ " + chiaSe.Masanpham + " đến bạn.";
                Msg.Body = "" + chiaSe.Thoigian;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("phamhuyhoalk20@gmail.com", "01635592943");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                }
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
