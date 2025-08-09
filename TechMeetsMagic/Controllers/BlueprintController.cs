using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMeetsMagic.ApplicationsServices.Services;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.ItemBlueprints;

namespace TechMeetsMagic.Controllers
{
    public class BlueprintController : Controller
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IBlueprintServices _blueprintServices;
        private readonly IFileServices _fileServices;

        public BlueprintController(TechMeetsMagicContext context, IBlueprintServices blueprintServices, IFileServices fileServices)
        {
            _context = context;
            _blueprintServices = blueprintServices;
            _fileServices = fileServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.Blueprints
                .OrderByDescending(y => y.BlueprintName)
                .Select(x => new BlueprintIndexViewModel
                {
                    ID = x.ID,
                    BlueprintName = x.BlueprintName,
                    BlueprintItemType = (Models.ItemBlueprints.BlueprintItemType)(Core.Dto.BlueprintItemType)x.BlueprintItemType,
                    Resources_Needed = x.Resources_Needed,
                });
            return View(ResultingInvetory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            BlueprintCreateViewModels vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlueprintCreateViewModels vm)
        {
            var dto = new BlueprintDto()
            {
                BlueprintName = vm.BlueprintName,
                Resources_Needed = vm.Resources_Needed,
                BlueprintItemType = (Core.Dto.BlueprintItemType)vm.BlueprintItemType,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    BlueprintID = x.BlueprintID,
                }).ToArray()
            };
            var result = await _blueprintServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var blueprint = await _blueprintServices.DetailsAsync(id);

            if (blueprint == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, titan is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.BlueprintId == id)
                .Select(y => new BlueprintImageViewModel
                {
                    BlueprintID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new BlueprintDetailsViewModel();
            vm.ID = blueprint.ID;
            vm.BlueprintName = blueprint.BlueprintName;
            vm.Resources_Needed = blueprint.Resources_Needed;
            vm.BlueprintItemType = (Models.ItemBlueprints.BlueprintItemType)blueprint.BlueprintItemType;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var blueprint = await _blueprintServices.DetailsAsync(id);

            if (blueprint == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.BlueprintId == id)
                .Select(y => new BlueprintImageViewModel
                {
                    BlueprintID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new BlueprintCreateViewModels();
            vm.ID = blueprint.ID;
            vm.BlueprintName = blueprint.BlueprintName;
            vm.Resources_Needed = blueprint.Resources_Needed;
            vm.BlueprintItemType = (Models.ItemBlueprints.BlueprintItemType)blueprint.BlueprintItemType;
            vm.CreatedAt = blueprint.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Images.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BlueprintCreateViewModels vm)
        {
            var dto = new BlueprintDto()
            {
                ID = (Guid)vm.ID,
                BlueprintName = vm.BlueprintName,
                Resources_Needed = vm.Resources_Needed,
                BlueprintItemType = (Core.Dto.BlueprintItemType)vm.BlueprintItemType,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    BlueprintID= x.BlueprintID,
                }).ToArray()
            };
            var result = await _blueprintServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var blueprint = await _blueprintServices.DetailsAsync(id);

            if (blueprint == null) { return NotFound(); }
            ;

            var images = await _context.FilesToDatabase
                .Where(x => x.BlueprintId == id)
                .Select(y => new BlueprintImageViewModel
                {
                    BlueprintID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new BlueprintDeleteViewModel();

            vm.ID = blueprint.ID;
            vm.BlueprintName = vm.BlueprintName;
            vm.Resources_Needed = vm.Resources_Needed;
            vm.BlueprintItemType = (Models.ItemBlueprints.BlueprintItemType)vm.BlueprintItemType;
            vm.CreatedAt = blueprint.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var titanToDelete = await _blueprintServices.Delete(id);

            if (titanToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(BlueprintImageViewModel vm)
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
