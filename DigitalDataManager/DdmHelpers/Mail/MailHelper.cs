using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.Mail
{
    class MailHelper
    {
        public string SmtpServer { get; private set; }
        public string MailFrom { get; private set; }
        public string MailPassword { get; private set; }

        private readonly SmtpClient _client;

        public MailHelper(string smtpServer, string mailFrom, string mailPassword)
        {
            SmtpServer = smtpServer;
            MailFrom = mailFrom;
            MailPassword = mailPassword;

            _client = new SmtpClient
            {
                Host = smtpServer,
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(MailFrom.Split('@')[0], mailPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }

        public void SendMail(MailEntity entity)
        {
            using (var mail = ToMailMessage(entity))
            {
                _client.Send(mail);
            }
        }

        private MailMessage ToMailMessage(MailEntity entity)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(MailFrom),
                Subject = entity.Subject,
                Body = entity.Message
            };

            foreach (var item in entity.MailsTo)
            {
                mail.To.Add(new MailAddress(item));
            }

            foreach (var item in entity.AttachFiles)
            {
                mail.Attachments.Add(new Attachment(item));
            }

            return mail;
        }
    }
}
