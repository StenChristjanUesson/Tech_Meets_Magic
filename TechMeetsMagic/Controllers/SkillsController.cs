using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMeetsMagic.ApplicationsServices.Services;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.PlayerSkills;

namespace TechMeetsMagic.Controllers
{
    public class SkillsController : Controller
    {
        private readonly TechMeetsMagicContext _context;
        private readonly ISkillService _skillService;
        private readonly IFileServices _fileServices;

        public SkillsController(TechMeetsMagicContext context, ISkillService skillService, IFileServices fileServices)
        {
            _context = context;
            _skillService = skillService;
            _fileServices = fileServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.Skills
                .OrderByDescending(y => y.SkillName)
                .Select(x => new SkillIndexViewModels
                {
                    ID = x.ID,
                    SkillName = x.SkillName,
                    SkillDescription = x.SkillDescription,
                    HealthAmountGainedFromHealingSkill = x.HealthAmountGainedFromHealingSkill,
                    SkillDamage = x.SkillDamage,
                    SkillmaxRange = x.SkillmaxRange,
                    SkillRangeStart = x.SkillRangeStart,
                    SkillActivationRangeStart = x.SkillActivationRangeStart,
                    SkillHitboxContactAffect = x.SkillHitboxContactAffect,
                    SkillActiveType = (Models.PlayerSkills.SkillActiveType)(Core.Dto.SkillActiveType)x.SkillActiveType,
                    SkillType = (Models.PlayerSkills.SkillType)(Core.Dto.SkillType)x.SkillType,
                    SkillTreeCategory = (Models.PlayerSkills.SkillTreeCategory)(Core.Dto.SkillTreeCategory)x.SkillTreeCategory,
                });
            return View(ResultingInvetory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SkillCreateViewModels vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SkillCreateViewModels vm)
        {
            var dto = new SkillDto()
            {
                SkillName = vm.SkillName,
                SkillDescription = vm.SkillDescription,
                HealthAmountGainedFromHealingSkill = vm.HealthAmountGainedFromHealingSkill,
                SkillDamage = vm.SkillDamage,
                SkillmaxRange = vm.SkillmaxRange,
                SkillRangeStart = vm.SkillRangeStart,
                SkillActivationRangeStart = vm.SkillActivationRangeStart,
                SkillHitboxContactAffect = vm.SkillHitboxContactAffect,
                SkillActiveType = (Core.Dto.SkillActiveType)vm.SkillActiveType,
                SkillType = (Core.Dto.SkillType)vm.SkillType,
                SkillTreeCategory = (Core.Dto.SkillTreeCategory)vm.SkillTreeCategory,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    SkillID = x.SkillID,
                }).ToArray()
            };
            var result = await _skillService.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var skill = await _skillService.DetailsAsync(id);

            if (skill == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, titan is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.SkillId == id)
                .Select(y => new SkillImageViewModel
                {
                    SkillID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new SkillDetailsViewModel();
            vm.ID = skill.ID;
            vm.SkillName = skill.SkillName;
            vm.SkillDescription = skill.SkillDescription;
            vm.HealthAmountGainedFromHealingSkill = skill.HealthAmountGainedFromHealingSkill;
            vm.SkillDamage = skill.SkillDamage;
            vm.SkillmaxRange = skill.SkillmaxRange;
            vm.SkillRangeStart = skill.SkillRangeStart;
            vm.SkillActivationRangeStart = skill.SkillActivationRangeStart;
            vm.SkillHitboxContactAffect = skill.SkillHitboxContactAffect;
            vm.SkillActiveType = (Models.PlayerSkills.SkillActiveType)skill.SkillActiveType;
            vm.SkillType = (Models.PlayerSkills.SkillType)skill.SkillType;
            vm.SkillTreeCategory = (Models.PlayerSkills.SkillTreeCategory)skill.SkillTreeCategory;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var skill = await _skillService.DetailsAsync(id);

            if (skill == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.AvatarId == id)
                .Select(y => new SkillImageViewModel
                {
                    SkillID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new SkillCreateViewModels();
            vm.ID = skill.ID;
            vm.SkillName = skill.SkillName;
            vm.SkillDescription = skill.SkillDescription;
            vm.HealthAmountGainedFromHealingSkill = skill.HealthAmountGainedFromHealingSkill;
            vm.SkillDamage = skill.SkillDamage;
            vm.SkillmaxRange = skill.SkillmaxRange;
            vm.SkillRangeStart = skill.SkillRangeStart;
            vm.SkillActivationRangeStart = skill.SkillActivationRangeStart;
            vm.SkillHitboxContactAffect = skill.SkillHitboxContactAffect;
            vm.SkillActiveType = (Models.PlayerSkills.SkillActiveType)skill.SkillActiveType;
            vm.SkillType = (Models.PlayerSkills.SkillType)skill.SkillType;
            vm.SkillTreeCategory = (Models.PlayerSkills.SkillTreeCategory)skill.SkillTreeCategory;
            vm.CreatedAt = skill.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Images.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SkillCreateViewModels vm)
        {
            var dto = new SkillDto()
            {
                ID = (Guid)vm.ID,
                SkillName = vm.SkillName,
                SkillDescription = vm.SkillDescription,
                SkillActivationRangeStart = 0,
                SkillHitboxContactAffect = vm.SkillHitboxContactAffect,
                HealthAmountGainedFromHealingSkill = 0,
                SkillmaxRange = 10,
                SkillDamage = 20,
                SkillRangeStart = 10,
                SkillActiveType = (Core.Dto.SkillActiveType)vm.SkillActiveType,
                SkillType = (Core.Dto.SkillType)vm.SkillType,
                SkillTreeCategory = (Core.Dto.SkillTreeCategory)vm.SkillTreeCategory,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    NpcID = x.SkillID,
                }).ToArray()
            };
            var result = await _skillService.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var skill = await _skillService.DetailsAsync(id);

            if (skill == null) { return NotFound(); }
            ;

            var images = await _context.FilesToDatabase
                .Where(x => x.SkillId == id)
                .Select(y => new SkillImageViewModel
                {
                    SkillID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new SkillDeleteViewModel();

            vm.ID = skill.ID;
            vm.SkillName = skill.SkillName;
            vm.SkillDescription = skill.SkillDescription;
            vm.HealthAmountGainedFromHealingSkill = skill.HealthAmountGainedFromHealingSkill;
            vm.SkillDamage = skill.SkillDamage;
            vm.SkillmaxRange = skill.SkillmaxRange;
            vm.SkillRangeStart = skill.SkillRangeStart;
            vm.SkillActivationRangeStart = skill.SkillActivationRangeStart;
            vm.SkillHitboxContactAffect = skill.SkillHitboxContactAffect;
            vm.SkillActiveType = (Models.PlayerSkills.SkillActiveType)skill.SkillActiveType;
            vm.SkillType = (Models.PlayerSkills.SkillType)skill.SkillType;
            vm.SkillTreeCategory = (Models.PlayerSkills.SkillTreeCategory)skill.SkillTreeCategory;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var titanToDelete = await _skillService.Delete(id);

            if (titanToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(SkillImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
    }
}
