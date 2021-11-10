using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Helpers
{
    public interface ISendMailHelper
    {
        bool SendMail(string emailnguoinhan, string body, string subject);
    }
    public class SendMailSvc : ISendMailHelper
    {
        public bool SendMail(string emailnguoinhan, string body, string subject)
        {
            try
            {
                //  NetworkCredential cred = new NetworkCredential("driverhuyhoa@gmail.com","01635592943");
                MailMessage Msg = new MailMessage();
                //sender email address
                Msg.From = new MailAddress("r4.clothes1@gmail.com");
                //Recipient e-mail address
                Msg.To.Add(emailnguoinhan);
                //Assign the subject  of out message
                Msg.Subject = subject;
                Msg.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("r4.clothes1@gmail.com", "R4Clothes");
                    smtp.EnableSsl = true;
                    smtp.Send(Msg);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
