using System.Net;
using olepunchy.Models;
using System.Threading.Tasks;
using System.Net.Mail;

namespace olepunchy.Services {
    
    public class MailService : IMailService {

        private readonly MailSettings _mailSettings;

        public MailService(MailSettings mailSettings) {
            _mailSettings = mailSettings;
        }

        public async Task SendEmailAsync(string fromAddress, string subject, string body) {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(_mailSettings.FromAddress);
            message.To.Add(new MailAddress(_mailSettings.ToAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            smtp.Port = _mailSettings.MailPort;
            smtp.Host = _mailSettings.MailServer;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.ToAddress, _mailSettings.MailPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
    }
}