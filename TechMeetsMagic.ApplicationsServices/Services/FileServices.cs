using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using static System.Net.Mime.MediaTypeNames;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly TechMeetsMagicContext _context;

        public FileServices
            (
                IHostEnvironment webHost,
                TechMeetsMagicContext context
            )
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(NpcDto npcdto, NPC npcdomain, AvatarDto avatardto, Avatar avatardomain, BlueprintDto blueprintdto, Blueprint blueprintdomain, SkillDto skilldto, Skill skilldomain, TheUserMadeOpenWorldDto theusermadeopenworld_dto, TheUserMadeOpenWorld theusermadeopenworld_domain)
        {
            if (npcdto.Files != null && npcdto.Files.Count > 0)
            {
                foreach (var image in npcdto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            NpcId = npcdomain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }

            if (avatardto.Files != null && avatardto.Files.Count > 0)
            {
                foreach (var image in avatardto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            NpcId = avatardomain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }

            if (blueprintdto.Files != null && blueprintdto.Files.Count > 0)
            {
                foreach (var image in blueprintdto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            NpcId = blueprintdomain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }

            if (skilldto.Files != null && skilldto.Files.Count > 0)
            {
                foreach (var image in skilldto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            NpcId = skilldomain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }

            if (theusermadeopenworld_dto.Files != null && theusermadeopenworld_dto.Files.Count > 0)
            {
                foreach (var image in theusermadeopenworld_dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            NpcId = theusermadeopenworld_domain.ID,
                        };
                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FilesToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FilesToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;
        }

        void IFileServices.UploadFilesToDatabase(NpcDto dto, NPC domain)
        {
            throw new NotImplementedException();
        }
    }
}
