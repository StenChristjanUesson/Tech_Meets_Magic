using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface IEmailServices
    { 
        void SendEmail(EmailDto dto);
        string SendEmailToken(EmailTokenDto dto, string token);
    }
}
