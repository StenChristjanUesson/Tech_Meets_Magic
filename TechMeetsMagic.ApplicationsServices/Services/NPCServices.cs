using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.ServicesInterface;
using TechMeetsMagic.Data;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class NPCServices : INPCServices
    {
        private readonly TechMeetsMagicContext _context;
        //private readonly iFileServices _fileservices;
        public NPCServices(TechMeetsMagicContext context/*, IFileServices fileServices*/)
        {
            _context = context;
            /*_fileServices = fileServices*/
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
    }
}
