using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMeetsMagic.ApplicationsServices.Services;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.TheGeneratedUserMadeOpenWorld;

namespace TechMeetsMagic.Controllers
{
    public class WorldController : Controller
    {
        private readonly TechMeetsMagicContext _context;
        private readonly ITheUserMadeOpenWorldService _worldservices;
        private readonly IFileServices _fileServices;

        public WorldController(TechMeetsMagicContext context, ITheUserMadeOpenWorldService worldService, IFileServices fileServices)
        {
            _context = context;
            _worldservices = worldService;
            _fileServices = fileServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.TheUserMadeOpenWorlds
                .OrderByDescending(y => y.WorldName)
                .Select(x => new TheUserMadeOpenWorldIndexViewModel
                {
                    ID = x.ID,
                    WorldName = x.WorldName,
                    WorldDescription = x.WorldDescription,
                    WorldImageUrl = x.WorldImageUrl,
                    WorldMapUrl = x.WorldMapUrl,
                });
            return View(ResultingInvetory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            TheUserMadeOpenWorldCreateViewModels vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (TheUserMadeOpenWorldCreateViewModels vm)
        {
            var dto = new TheUserMadeOpenWorldDto()
            {
                WorldName = vm.WorldName,
                WorldDescription = vm.WorldDescription,
                WorldImageUrl = vm.WorldImageUrl,
                WorldMapUrl = vm.WorldMapUrl,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    TheUserMadeOpenWorldID = x.TheUserMadeOpenWorldID,
                }).ToArray()
            };
            var result = await _worldservices.Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var world = await _worldservices.DetailsAsync(id);

            if (world == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, titan is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.TheUserMadeOpenWorldId == id)
                .Select(y => new TheUserMadeOpenWorldImageViewModel
                {
                    TheUserMadeOpenWorldID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new TheUserMadeOpenWorldDetailsViewModel();
            vm.ID = world.ID;
            vm.WorldName = world.WorldName;
            vm.WorldDescription = world.WorldDescription;
            vm.WorldImageUrl = world.WorldImageUrl;
            vm.WorldMapUrl = world.WorldMapUrl;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var world = await _worldservices.DetailsAsync(id);

            if (world == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.TheUserMadeOpenWorldId == id)
                .Select(y => new TheUserMadeOpenWorldImageViewModel
                {
                    TheUserMadeOpenWorldID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new TheUserMadeOpenWorldCreateViewModels();
            vm.ID = world.ID;
            vm.WorldName = world.WorldName;
            vm.WorldDescription = world.WorldDescription;
            vm.WorldImageUrl = world.WorldImageUrl;
            vm.WorldMapUrl = world.WorldMapUrl;
            vm.CreatedAt = world.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Images.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TheUserMadeOpenWorldCreateViewModels vm)
        {
            var dto = new TheUserMadeOpenWorldDto()
            {
                ID = (Guid)vm.ID,
                WorldName = vm.WorldName,
                WorldDescription = vm.WorldDescription,
                WorldImageUrl = vm.WorldImageUrl,
                WorldMapUrl = vm.WorldMapUrl,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    TheUserMadeOpenWorldID = x.TheUserMadeOpenWorldID,
                }).ToArray()
            };
            var result = await _worldservices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var world = await _worldservices.DetailsAsync(id);

            if (world == null) { return NotFound(); }
            ;

            var images = await _context.FilesToDatabase
                .Where(x => x.TheUserMadeOpenWorldId == id)
                .Select(y => new TheUserMadeOpenWorldImageViewModel
                {
                    TheUserMadeOpenWorldID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new TheUserMadeOpenWorldDeleteViewModel();

            vm.ID = world.ID;
            vm.WorldName = world.WorldName;
            vm.WorldDescription = world.WorldDescription;
            vm.WorldImageUrl = world.WorldImageUrl;
            vm.WorldMapUrl = world.WorldMapUrl;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var titanToDelete = await _worldservices.Delete(id);

            if (titanToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(TheUserMadeOpenWorldImageViewModel vm)
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
