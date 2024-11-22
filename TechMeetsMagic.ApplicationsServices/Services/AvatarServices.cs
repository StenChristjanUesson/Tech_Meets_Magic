using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class AvatarServices
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileservices;
        public AvatarServices(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileservices = fileServices;
        }
        public async Task<AvatarServices> DetailsAsync(Guid id)
        {
            var result = await _context.Avatars
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
    }
}
