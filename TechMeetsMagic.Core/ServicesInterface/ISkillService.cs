using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.ServicesInterface
{
    public interface ISkillService
    {
        Task<Skill> DetailsAsync(Guid id);
        Task<Skill> Create(SkillDto dto);
        Task<Skill> Update(SkillDto dto);
        Task<Skill> Delete(Guid id);
    }
}
