using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ddm.Helpers.Mail
{
    public class MailEntity
    {
        public string Subject { get; private set; }
        public string Message { get; private set; }

        private readonly List<string> _mailsTo;
        private readonly List<string> _attachFiles;

        public MailEntity(string subject, string message, string mailTo)
        {
            Subject = subject;
            Message = message;

            _mailsTo = new List<string>();
            _attachFiles = new List<string>();

            _mailsTo.Add(mailTo);
        }

        public List<string> MailsTo
        {
            get { return _mailsTo; }
        }

        public List<string> AttachFiles
        {
            get { return _attachFiles; }
        }
    }
}
