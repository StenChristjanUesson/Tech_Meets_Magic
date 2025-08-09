using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(NpcDto dto, NPC domain);
        void UploadFilesToDatabase(AvatarDto dto, Avatar domain);
        void UploadFilesToDatabase(SkillDto dto, Skill domain);
        void UploadFilesToDatabase(TheUserMadeOpenWorldDto dto, TheUserMadeOpenWorld domain);
        void UploadFilesToDatabase(BlueprintDto dto, Blueprint domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
