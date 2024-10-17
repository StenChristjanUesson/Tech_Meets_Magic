using Microsoft.AspNetCore.Mvc;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.NonPlayerCharacters;

namespace TechMeetsMagic.Controllers
{
    public class NPCController : Controller
    {
        /*
         * NPCController controlls all functions of the NPC's: Speaking, giving quests, shop, being a fucking companion jne.
         */
        private readonly TechMeetsMagicContext _context;
        private readonly INPCServices _npcServices;
        public NPCController(TechMeetsMagicContext context, INPCServices npcServices)
        {
            _context = context;
            _npcServices = npcServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.NPCs
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
