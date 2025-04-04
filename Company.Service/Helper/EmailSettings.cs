using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail(Email input)
        {
            var clinte=new SmtpClient("smtp.gmail.com", 587);
            clinte.EnableSsl = true;
            clinte.Credentials = new NetworkCredential("gamaltolan4@gmail.com", "xnrcgeoilwuopytq");
            clinte.Send("gamaltolan4@gmail.com", input.To, input.Subject, input.Body);

        }
    }
}
