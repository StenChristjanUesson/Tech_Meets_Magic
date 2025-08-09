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

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class TheUserMadeOpenWorldService : ITheUserMadeOpenWorldService
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileservices;
        public TheUserMadeOpenWorldService(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileservices = fileServices;
        }

        /// <summary>
        /// Get Details for one Npc
        /// </summary>
        /// <param name="id">id of Npc to show details of</param>
        /// <returns>resulting Npc</returns>

        public async Task<TheUserMadeOpenWorld> DetailsAsync(Guid id)
        {
            var result = await _context.TheUserMadeOpenWorlds
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<TheUserMadeOpenWorld> Create(TheUserMadeOpenWorldDto dto)
        {
            // set by service
            TheUserMadeOpenWorld theusermadeopenworld = new();
            theusermadeopenworld.ID = Guid.NewGuid();
            theusermadeopenworld.WorldName = "Admin_World_Test";
            theusermadeopenworld.WorldDescription = "Test_World";
            theusermadeopenworld.WorldImageUrl = "Non_Currently";
            theusermadeopenworld.WorldMapUrl = "Non_Currently";


            // set for db
            theusermadeopenworld.CreatedAt = DateTime.Now;
            theusermadeopenworld.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, theusermadeopenworld);
            }

            await _context.TheUserMadeOpenWorlds.AddAsync(theusermadeopenworld);
            await _context.SaveChangesAsync();

            return theusermadeopenworld;
        }

        public async Task<TheUserMadeOpenWorld> Update(TheUserMadeOpenWorldDto dto)
        {
            TheUserMadeOpenWorld theusermadeopenworld = new TheUserMadeOpenWorld();
            // set by service

            theusermadeopenworld.ID = dto.ID;
            //theusermadeopenworld.


            // Chosen by user
            //theusermadeopenworld.

            // set for db
            theusermadeopenworld.CreatedAt = dto.CreatedAt;
            theusermadeopenworld.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, theusermadeopenworld);
            }

            _context.TheUserMadeOpenWorlds.Update(theusermadeopenworld);
            await _context.SaveChangesAsync();

            return theusermadeopenworld;
        }
        public async Task<TheUserMadeOpenWorld> Delete(Guid id)
        {
            var result = await _context.TheUserMadeOpenWorlds
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.TheUserMadeOpenWorlds.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
