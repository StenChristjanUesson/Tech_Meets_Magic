using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.NonPlayerCharacters;

namespace TechMeetsMagic.Controllers
{
    public class NPCsController : Controller
    {
        /*
         * NPCController controlls all functions of the NPC's: Speaking, giving quests, shop, being a fucking companion jne.
         */
        private readonly TechMeetsMagicContext _context;
        private readonly INPCServices _npcServices;
        public NPCsController(TechMeetsMagicContext context, INPCServices npcServices)
        {
            _context = context;
            _npcServices = npcServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.NPCs
                .OrderByDescending(y => y.NpcType)
                .Select(x => new NpcIndexViewModels
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

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NpcCreateViewModels vm) 
        {
            var dto = new NpcDto()
            {
                NPCName = vm.NPCName,
                NPCDescribtion = vm.NPCDescribtion,
                NPCLevel = 0,
                NPCMaxHP = 100,
                NPCCurrentHP = 100,
                NPCAttackDamage = vm.NPCAttackDamage,
                NPCStatus = (Core.Dto.NPCStatus)vm.NPCStatus,
                NpcType = (Core.Dto.NpcType)vm.NpcType,
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

            if (resutl == null) 
            { 
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var npc = await _npcServices.DetailsAsync(id);

            if (npc == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToDatabase
                .Where(T => T.NpcId == id)
                .Select(y => new NpcImageViewModel
                {
                    NpcID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new NpcDetailsViewModel();
            vm.ID = npc.ID;
            vm.NPCName = npc.NPCName;
            vm.NPCDescribtion = npc.NPCDescribtion;
            vm.NPCLevel = npc.NPCLevel;
            vm.NPCMaxHP = npc.NPCMaxHP;
            vm.NPCCurrentHP = npc.NPCCurrentHP;
            vm.NPCAttackDamage = npc.NPCAttackDamage;
            vm.NPCStatus = (Models.NonPlayerCharacters.NPCStatus) npc.NPCStatus;
            vm.NpcType = (NPCType) npc.NpcType;
            vm.Images.AddRange(images);

            return View(vm);            
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }
            var Npc = await _npcServices.DetailsAsync(id);
            if (Npc == null) { return NotFound(); }
            var images = await _context.FilesToDatabase
                .Where(x => x.NpcId == id)
                .Select(y => new NpcImageViewModel
                {
                    NpcID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new NpcCreateViewModels();
            vm.ID = Npc.ID;
            vm.NPCName = Npc.NPCName;
            vm.NPCDescribtion = Npc.NPCDescribtion;
            vm.NPCLevel = Npc.NPCLevel;
            vm.NPCMaxHP = Npc.NPCMaxHP;
            vm.NPCCurrentHP = Npc.NPCCurrentHP;
            vm.NPCAttackDamage = Npc.NPCAttackDamage;
            vm.NPCStatus = (Models.NonPlayerCharacters.NPCStatus)Npc.NPCStatus;
            vm.NpcType = (NPCType)Npc.NpcType;
            vm.CreatedAt = Npc.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Images.AddRange(images);
            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(NpcCreateViewModels vm)
        {
            var dto = new NpcDto()
            {
                NPCName = vm.NPCName,
                NPCDescribtion = vm.NPCDescribtion,
                NPCLevel = 0,
                NPCMaxHP = 100,
                NPCCurrentHP = 100,
                NPCAttackDamage = vm.NPCAttackDamage,
                NPCStatus = (Core.Dto.NPCStatus)vm.NPCStatus,
                NpcType = (Core.Dto.NpcType)vm.NpcType,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    NpcID = x.NpcID,
                }).ToArray()
            };
            var result = await _npcServices.Update(dto);
            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
    }
}
