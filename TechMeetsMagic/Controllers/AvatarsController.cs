using Microsoft.AspNetCore.Mvc;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;

namespace TechMeetsMagic.Controllers
{
    public class AvatarsController : Controller
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileServices;
        public AvatarsController(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
    }
}
