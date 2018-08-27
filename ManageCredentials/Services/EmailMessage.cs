using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Services
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddress = new List<EmailAddress>();
            FromAddress = new List<EmailAddress>();
        }
        public List<EmailAddress> ToAddress { get; set; }
        public List<EmailAddress> FromAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
