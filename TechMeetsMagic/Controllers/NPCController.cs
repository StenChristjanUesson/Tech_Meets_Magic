using Microsoft.AspNetCore.Mvc;
using TechMeetsMagic.Core.Dto;
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

        [HttpGet]
        public IActionResult Create()
        {
            NpcCreateViewModels vm = new();
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NpcCreateViewModels vm) 
        {
            var dto = new NpcDto()
            {
                NPCName = vm.NPCName,
                NPCDescribtion = vm.NPCDescribtion,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    NpcID = x.NpcID,
                }).ToArray()
            };
            var resutl = await _npcServices.Create(dto);

            if (resutl != null) 
            { 
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
