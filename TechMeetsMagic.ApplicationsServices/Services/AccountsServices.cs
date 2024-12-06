using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.Dto.AccountsDtos;
using TechMeetsMagic.Core.ServicesInterface;
namespace TechMeetsMagic.ApplicationsServices.Services

{
    public class AccountsServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailServices _emailServices;

        public AccountsServices
            (
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager,
                IEmailServices emailServices
            )
        {
            _UserManager = userManager;
            _signInManager = signInManager;
            _emailServices = emailServices;
        }

        public async Task<ApplicationUser> Register( ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City = dto.City
            };
            var result = await _UserManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                var token = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
                _emailServices.SendEmailToken(new EmailTokenDto(), token);
            }
            return user;
        }

        public async Task<ApplicationUser> ConfirmEmail(string userId, string token)
        {
            var user = await _UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                string errorMessage = $"User with id {userId} is not valid.";
            }
            var result = await _UserManager.ConfirmEmailAsync(user, token);
            return user;
        }

        public async Task<ApplicationUser> Login(LoginDto dto)
        {
            // !!extval
            var user = await _UserManager.FindByEmailAsync(dto.Email);
            return user;
        }
    }
}
