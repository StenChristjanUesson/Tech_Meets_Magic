using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Data;
using Microsoft.EntityFrameworkCore;

namespace TechMeetsMagic.ApplicationServices.Services
{
    public class PlayerProfilesServices : IPlayerProfilesServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TechMeetsMagicContext _context;
        public PlayerProfilesServices
            (
                UserManager<ApplicationUser> userManager,
                TechMeetsMagicContext context
            )
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<PlayerProfile> DetailsAsync(Guid id)
        {
            string stringid = id.ToString();
            var result = await _context.PlayerProfiles
                .FirstOrDefaultAsync(x => x.ApplicationUserID == stringid);
            return result;
        }
        public async Task<PlayerProfile> Create(string useridfor)
        {
            var user = await _userManager.FindByIdAsync(useridfor);
            string userid = user.Id;
            var profile = new PlayerProfile()
            {
                ID = new Guid(),
                ApplicationUserID = userid,
                ScreenName = "",
                CurrentStatus = ProfileStatus.Active,
                ProfileType = false,
                ProfileStatusLastChangedAt = DateTime.UtcNow,
                ProfileAttributedToAnAccountUserAt = DateTime.UtcNow,
                ProfileCreatedAt = DateTime.UtcNow,
                ProfileModifiedAt = DateTime.UtcNow,
            };
            return profile;
        }
    }

}