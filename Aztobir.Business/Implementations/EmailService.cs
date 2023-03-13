using System.Net;
using System.Net.Mail;

namespace Aztobir.Business.Implementations
{
    public static class EmailService
    {
        public static void Send(string fromMail, string password, string toMail, string body, string subject)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential(fromMail, password);
                client.EnableSsl = true;
                var msg = new MailMessage(fromMail, toMail);
                msg.Body = body;
                msg.Subject = subject;
                msg.IsBodyHtml = true;
                client.Send(msg);
            }
        }
    }
}
