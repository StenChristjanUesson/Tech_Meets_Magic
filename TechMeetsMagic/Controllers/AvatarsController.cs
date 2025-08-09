using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechMeetsMagic.ApplicationsServices.Services;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using TechMeetsMagic.Models.AvatarAppearence;
using AvatarGender = TechMeetsMagic.Models.AvatarAppearence.AvatarGender;
using AvatarSkinColor = TechMeetsMagic.Models.AvatarAppearence.AvatarSkinColor;
using AvatarHairColor = TechMeetsMagic.Models.AvatarAppearence.AvatarHairColor;
using AvatarHairLenght = TechMeetsMagic.Models.AvatarAppearence.AvatarHairLenght;
using AvatarEyeColor = TechMeetsMagic.Models.AvatarAppearence.AvatarEyeColor;

namespace TechMeetsMagic.Controllers
{
    public class AvatarsController : Controller
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IAvatarServices _avatarServices;
        private readonly IFileServices _fileServices;

        public AvatarsController(TechMeetsMagicContext context, IAvatarServices avatarServices, IFileServices fileServices)
        {
            _context = context;
            _avatarServices = avatarServices;
            _fileServices = fileServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var ResultingInvetory = _context.Avatars
                .OrderByDescending(y => y.AvatarGender)
                .Select(x => new AvatarIndexViewModel
                {
                    ID = x.ID,
                    AvatarGender = (AvatarGender)x.AvatarGender,
                    AvatarSkinColor = (AvatarSkinColor)x.AvatarSkinColor,
                    AvatarHairColor = (AvatarHairColor)x.AvatarHairColor,
                    AvatarHairLenght = (AvatarHairLenght)x.AvatarHairLenght,
                    AvatarEyeColor = (AvatarEyeColor)x.AvatarEyeColor,
                });
            return View(ResultingInvetory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            AvatarCreateViewModels vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvatarCreateViewModels vm)
        {
            var dto = new AvatarDto()
            {
                AvatarGender = (Core.Dto.AvatarGender)vm.AvatarGender,
                AvatarSkinColor = (Core.Dto.AvatarSkinColor)vm.AvatarSkinColor,
                AvatarHairColor = (Core.Dto.AvatarHairColor)vm.AvatarEyeColor,
                AvatarHairLenght = (Core.Dto.AvatarHairLenght)vm.AvatarHairLenght,
                AvatarEyeColor = (Core.Dto.AvatarEyeColor)vm.AvatarEyeColor,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    AvatarID = x.AvatarID,
                }).ToArray()
            };
            var result = await _avatarServices .Create(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var avatar = await _avatarServices.DetailsAsync(id);

            if (avatar == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, titan is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.AvatarId == id)
                .Select(y => new AvatarImageViewModel
                {
                    AvatarID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new AvatarDetailsViewModel();
            vm.ID = avatar.ID;
            vm.AvatarGender = (Models.AvatarAppearence.AvatarGender)avatar.AvatarGender;
            vm.AvatarSkinColor = (Models.AvatarAppearence.AvatarSkinColor)avatar.AvatarSkinColor;
            vm.AvatarHairColor = (Models.AvatarAppearence.AvatarHairColor)avatar.AvatarEyeColor;
            vm.AvatarHairLenght = (Models.AvatarAppearence.AvatarHairLenght)avatar.AvatarHairLenght;
            vm.AvatarEyeColor = (Models.AvatarAppearence.AvatarEyeColor)avatar.AvatarEyeColor;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var avatar = await _avatarServices.DetailsAsync(id);

            if (avatar == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.AvatarId == id)
                .Select(y => new AvatarImageViewModel
                {
                    AvatarID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new AvatarCreateViewModels();
            vm.ID = avatar.ID;
            vm.AvatarGender = (Models.AvatarAppearence.AvatarGender)avatar.AvatarGender;
            vm.AvatarSkinColor = (Models.AvatarAppearence.AvatarSkinColor)avatar.AvatarSkinColor;
            vm.AvatarHairColor = (Models.AvatarAppearence.AvatarHairColor)avatar.AvatarHairColor;
            vm.AvatarHairLenght = (Models.AvatarAppearence.AvatarHairLenght)avatar.AvatarEyeColor;
            vm.AvatarEyeColor = (Models.AvatarAppearence.AvatarEyeColor)avatar.AvatarEyeColor;
            vm.CreatedAt = avatar.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Images.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(AvatarCreateViewModels vm)
        {
            var dto = new AvatarDto()
            {
                ID = (Guid)vm.ID,
                AvatarGender = (Core.Dto.AvatarGender)vm.AvatarGender,
                AvatarSkinColor = (Core.Dto.AvatarSkinColor)vm.AvatarSkinColor,
                AvatarHairColor = (Core.Dto.AvatarHairColor)vm.AvatarEyeColor,
                AvatarHairLenght = (Core.Dto.AvatarHairLenght)vm.AvatarHairLenght,
                AvatarEyeColor = (Core.Dto.AvatarEyeColor)vm.AvatarEyeColor,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                image = vm.Images
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    AvatarID = x.AvatarID,
                }).ToArray()
            };
            var result = await _avatarServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var avatar = await _avatarServices.DetailsAsync(id);

            if (avatar == null) { return NotFound(); }
            ;

            var images = await _context.FilesToDatabase
                .Where(x => x.AvatarId == id)
                .Select(y => new AvatarImageViewModel
                {
                    AvatarID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new AvatarDeleteViewModel();

            vm.ID = avatar.ID;
            vm.AvatarGender = (Models.AvatarAppearence.AvatarGender)avatar.AvatarGender;
            vm.AvatarSkinColor = (Models.AvatarAppearence.AvatarSkinColor)avatar.AvatarSkinColor;
            vm.AvatarHairColor = (Models.AvatarAppearence.AvatarHairColor)avatar.AvatarHairColor;
            vm.AvatarHairLenght = (Models.AvatarAppearence.AvatarHairLenght)avatar.AvatarEyeColor;
            vm.AvatarEyeColor = (Models.AvatarAppearence.AvatarEyeColor)avatar.AvatarEyeColor;
            vm.Images.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var titanToDelete = await _avatarServices.Delete(id);

            if (titanToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(AvatarImageViewModel vm)
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
