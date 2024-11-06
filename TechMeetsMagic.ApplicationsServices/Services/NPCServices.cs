using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;
using NPCStatus = TechMeetsMagic.Core.Domain.NPCStatus;
using NpcType = TechMeetsMagic.Core.Domain.NpcType;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class NPCServices : INPCServices
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileservices;
        public NPCServices(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileservices = fileServices;
        }

        /// <summary>
        /// Get Details for one Npc
        /// </summary>
        /// <param name="id">id of Npc to show details of</param>
        /// <returns>resulting Npc</returns>

        public async Task<NPC> DetailsAsync(Guid id)
        {
            var result = await _context.NPCs
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<NPC> Create(NpcDto dto)
        {
            // set by service
            NPC npc = new();
            npc.ID = Guid.NewGuid();
            npc.NPCCurrentHP = 100;
            npc.NPCAttackDamage = 100;
            npc.NPCMaxHP = 100;
            npc.NPCStatus = (NPCStatus)dto.NPCStatus;
            
            // set by user
            npc.NpcType = (NpcType)dto.NpcType;

            // set for db
            npc.CreatedAt = DateTime.Now;
            npc.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, npc);
            }

            await _context.NPCs.AddAsync(npc);
            await _context.SaveChangesAsync();

            return npc;
        }
    }
}
