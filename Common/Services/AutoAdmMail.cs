using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Timers;

namespace Common.Services
{
    class AutoAdminMailing
    {
        public void CreateMail()
        {
            var message = new MailMessage();
            message.From = new MailAddress("adres nadawcy");
            message.To.Add(new MailAddress("adres odbiorcy"));
            message.Subject = "Temat";
            message.Body = "Treść";

            var smtp = new SmtpClient("adres smtp");
            smtp.Credentials = new NetworkCredential("adres nadawcy", "hasło do poczty");
            smtp.EnableSsl = true;
            smtp.Port = 587;

            smtp.Send(message);
        }
    }
}
