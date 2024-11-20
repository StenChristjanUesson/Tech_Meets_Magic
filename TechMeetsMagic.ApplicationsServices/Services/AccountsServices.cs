using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.ServicesInterface;
namespace TechMeetsMagic.ApplicationsServices.Services

{
    public class AccountsServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsServices
            (
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager
            )
        {
            _UserManager = userManager;
            _signInManager = signInManager;
        }
    }
}
