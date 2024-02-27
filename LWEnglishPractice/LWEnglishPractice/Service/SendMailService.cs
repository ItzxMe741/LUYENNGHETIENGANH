using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.Service
{
    public class SendMailService
    {
        MailSettings _mailSettings { get; set; }
        public SendMailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public SendMailService()
        {
        }

        public string SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress("HienCa", "dtny050601@gmail.com");
            email.From.Add(new MailboxAddress("HienCa", "dtny050601@gmail.com"));

            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.CheckCertificateRevocation = false;
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("dtny050601@gmail.com", "ycfbcfyjtyzlammz");
                smtp.Send(email);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "ERROR" + e.Message;
            }


            smtp.Disconnect(true);
            return "Successful mailing";
        }
    }
}
public class MailContent
{
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

}


