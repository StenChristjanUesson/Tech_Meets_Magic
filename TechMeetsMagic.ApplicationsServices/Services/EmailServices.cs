using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmailToken(EmailTokenDto dto, string token)
        {
            dto.token = token;
            var email = new MimeMessage();

            _configuration.GetSection("EmailUserName").Value = "StenUesson";
            _configuration.GetSection("EmailHost").Value = "smtp.gmail.com";
            _configuration.GetSection("EmailPassword").Value = "tvpv uopv ozrb ajut";

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body += dto.token,
            };

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            //google smtp app password = TechMeetsMagicSMTP tvpv uopv ozrb ajut
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 567, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }

        void IEmailServices.SendEmail(EmailDto dto)
        {
            throw new NotImplementedException();
        }

        string IEmailServices.SendEmailToken(EmailTokenDto dto, string token)
        {
            throw new NotImplementedException();
        }
    }
}
