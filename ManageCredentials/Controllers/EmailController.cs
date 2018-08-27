using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageCredentials.Services;
using ManageCredentials.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ManageCredentials.Controllers
{
    public class EmailController : Controller
    {
        private IEmailService emailService;
        private IHostingEnvironment environment;
        public EmailController(IEmailService email, IHostingEnvironment env)
        {
            emailService = email;
            environment = env;
        }
        
        public void Index()
        {
            var content = new Container(environment);
            var data = content.Content();
            var newdata = string.Join(" ", data);
            var EmailMessage = new EmailMessage()
            {
                ToAddress = new List<EmailAddress>()
                {
                    new EmailAddress() { Name = "Justice",Address="justicea83@gmail.com"}
                },
                FromAddress = new List<EmailAddress>()
                {
                     new EmailAddress() { Name = "Justice", Address = "justicea83@gmail.com" }
                },
                Subject = "Lorem Ipsum Donor",
                Content = newdata

            };
            emailService.Send(EmailMessage);
        }
    }
}