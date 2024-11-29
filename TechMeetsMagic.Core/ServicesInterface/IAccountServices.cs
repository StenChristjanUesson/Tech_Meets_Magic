using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.Dto.AccountsDtos;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface IAccountServices
    {
        Task<ApplicationUser> ConfirmEmail(string userId, string token);

        Task<ApplicationUser> Register(ApplicationUserDto dto);

        Task<ApplicationUser> Login(LoginDto dto);
    }
}
