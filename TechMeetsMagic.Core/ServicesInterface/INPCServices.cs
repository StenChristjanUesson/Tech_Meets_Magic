using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface INPCServices
    {
        Task<NPC> DetailsAsync(Guid id);
        Task<NPC> Create(NpcDto dto);
    }
}
