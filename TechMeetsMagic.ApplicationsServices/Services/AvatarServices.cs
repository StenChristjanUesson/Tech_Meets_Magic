using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using AvatarEyeColor = TechMeetsMagic.Core.Domain.AvatarEyeColor;
using AvatarGender = TechMeetsMagic.Core.Domain.AvatarGender;
using AvatarHairColor = TechMeetsMagic.Core.Domain.AvatarHairColor;
using AvatarHairLenght = TechMeetsMagic.Core.Domain.AvatarHairLenght;
using AvatarSkinColor = TechMeetsMagic.Core.Domain.AvatarSkinColor;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class AvatarServices : IAvatarServices
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileservices;
        public AvatarServices(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileservices = fileServices;
        }

        /// <summary>
        /// Get Details for one Npc
        /// </summary>
        /// <param name="id">id of Npc to show details of</param>
        /// <returns>resulting Npc</returns>

        public async Task<Avatar> DetailsAsync(Guid id)
        {
            var result = await _context.Avatars
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Avatar> Create(AvatarDto dto)
        {
            // set by service
            Avatar avatar = new();
            avatar.ID = Guid.NewGuid();

            // Chosen by user
            avatar.AvatarGender = (AvatarGender)dto.AvatarGender;
            avatar.AvatarSkinColor = (AvatarSkinColor)dto.AvatarSkinColor;
            avatar.AvatarHairColor = (AvatarHairColor)dto.AvatarHairColor;
            avatar.AvatarHairLenght = (AvatarHairLenght)dto.AvatarHairLenght;
            avatar.AvatarEyeColor = (AvatarEyeColor)dto.AvatarEyeColor;

            // set for db
            avatar.CreatedAt = DateTime.Now;
            avatar.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, avatar);
            }

            await _context.Avatars.AddAsync(avatar);
            await _context.SaveChangesAsync();

            return avatar;
        }

        public async Task<Avatar> Update(AvatarDto dto)
        {
            Avatar avatar = new Avatar();
            
            // set by service

            avatar.ID = dto.ID;
            
            // Chosen by user
            avatar.AvatarGender = (AvatarGender)dto.AvatarGender;
            avatar.AvatarSkinColor = (AvatarSkinColor)dto.AvatarSkinColor;
            avatar.AvatarHairColor = (AvatarHairColor)dto.AvatarHairColor;
            avatar.AvatarHairLenght = (AvatarHairLenght)dto.AvatarHairLenght;
            avatar.AvatarEyeColor = (AvatarEyeColor)dto.AvatarEyeColor;

            // set for db
            avatar.CreatedAt = dto.CreatedAt;
            avatar.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, avatar);
            }

            _context.Avatars.Update(avatar);
            await _context.SaveChangesAsync();

            return avatar;
        }
        public async Task<Avatar> Delete(Guid id)
        {
            var result = await _context.Avatars
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Avatars.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
