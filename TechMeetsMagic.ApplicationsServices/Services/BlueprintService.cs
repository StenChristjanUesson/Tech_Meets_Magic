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
using BlueprintItemType = TechMeetsMagic.Core.Domain.BlueprintItemType;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class BlueprintService : IBlueprintServices
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileservices;
        public BlueprintService(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileservices = fileServices;
        }

        /// <summary>
        /// Get Details for one Npc
        /// </summary>
        /// <param name="id">id of Npc to show details of</param>
        /// <returns>resulting Npc</returns>

        public async Task<Blueprint> DetailsAsync(Guid id)
        {
            var result = await _context.Blueprints
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Blueprint> Create(BlueprintDto dto)
        {
            // set by service
            Blueprint blueprint = new();
            blueprint.ID = Guid.NewGuid();
            blueprint.BlueprintName = "Steel Sword";
            blueprint.Resources_Needed = "Iron, Steel, Leather";
            blueprint.BlueprintItemType = BlueprintItemType.Weapon;

            // set for db
            blueprint.CreatedAt = DateTime.Now;
            blueprint.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, blueprint);
            }

            await _context.Blueprints.AddAsync(blueprint);
            await _context.SaveChangesAsync();

            return blueprint;
        }

        public async Task<Blueprint> Update(BlueprintDto dto)
        {
            Blueprint blueprint = new Blueprint();
            // set by service

            blueprint.ID = dto.ID;
            blueprint.BlueprintName = dto.BlueprintName;
            blueprint.Resources_Needed = dto.Resources_Needed;
            blueprint.BlueprintItemType = (BlueprintItemType)dto.BlueprintItemType;

            // set for db
            blueprint.CreatedAt = dto.CreatedAt;
            blueprint.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, blueprint);
            }

            _context.Blueprints.Update(blueprint);
            await _context.SaveChangesAsync();

            return blueprint;
        }
        public async Task<Blueprint> Delete(Guid id)
        {
            var result = await _context.Blueprints
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Blueprints.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
