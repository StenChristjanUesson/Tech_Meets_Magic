using Microsoft.AspNetCore.Mvc;
using TechMeetsMagic.ApplicationsServices.Services;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.NonPlayerCharacters;

namespace TechMeetsMagic.Controllers
{
    public class AvatarsController : Controller
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileServices;

        public AvatarsController(TechMeetsMagicContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.
                .OrderByDescending(y => y.NpcType)
                .Select(x => new NPCIndexViewModels
                {
                    ID = x.ID,
                    NPCName = x.NPCName,
                    NPCDescribtion = x.NPCDescribtion,
                    NpcType = (NPCType)x.NpcType,
                    NPCLevel = x.NPCLevel,
                });
            return View(ResultingInvetory);
        }
    }
}
