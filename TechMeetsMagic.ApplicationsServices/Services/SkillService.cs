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
using SkillActiveType = TechMeetsMagic.Core.Domain.SkillActiveType;
using SkillType = TechMeetsMagic.Core.Domain.SkillType;
using SkillTreeCategory = TechMeetsMagic.Core.Domain.SkillTreeCategory;

namespace TechMeetsMagic.ApplicationsServices.Services
{
    public class SkillServices : ISkillService
    {
        private readonly TechMeetsMagicContext _context;
        private readonly IFileServices _fileservices;
        public SkillServices(TechMeetsMagicContext context, IFileServices fileServices)
        {
            _context = context;
            _fileservices = fileServices;
        }

        /// <summary>
        /// Get Details for one Npc
        /// </summary>
        /// <param name="id">id of Npc to show details of</param>
        /// <returns>resulting Npc</returns>

        public async Task<Skill> DetailsAsync(Guid id)
        {
            var result = await _context.Skills
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Skill> Create(SkillDto dto)
        {
            // set by service
            Skill skill = new();
            skill.ID = Guid.NewGuid();
            skill.SkillHitboxContactAffect = "Damage";
            skill.SkillDamage = 100;
            skill.SkillActiveType = (SkillActiveType)dto.SkillActiveType;
            skill.SkillmaxRange = 100;
            skill.SkillType = (SkillType)dto.SkillType;
            skill.SkillTreeCategory = (SkillTreeCategory)dto.SkillTreeCategory;
            skill.SkillName = "Fireball";
            skill.SkillDescription = "A powerful fireball that deals damage to enemies.";
            skill.SkillRangeStart = 0;
            skill.HealthAmountGainedFromHealingSkill = 50; 

            // Chosen by user
            skill.SkillActivationRangeStart = dto.SkillActivationRangeStart;

            // set for db
            skill.CreatedAt = DateTime.Now;
            skill.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, skill);
            }

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<Skill> Update(SkillDto dto)
        {
            Skill skill = new Skill();
            // set by service

            skill.ID = dto.ID;
            skill.SkillHitboxContactAffect = dto.SkillHitboxContactAffect;
            skill.SkillDamage = dto.SkillDamage;
            skill.SkillActiveType = (SkillActiveType)dto.SkillActiveType;
            skill.SkillmaxRange = dto.SkillmaxRange;
            skill.SkillType = (SkillType)dto.SkillType;
            skill.SkillTreeCategory = (SkillTreeCategory)dto.SkillTreeCategory;
            skill.SkillName = dto.SkillName;
            skill.SkillDescription = dto.SkillDescription;
            skill.SkillRangeStart = dto.SkillRangeStart;
            skill.HealthAmountGainedFromHealingSkill = dto.HealthAmountGainedFromHealingSkill;


            // Chosen by user
            skill.SkillActivationRangeStart = dto.SkillActivationRangeStart;

            // set for db
            skill.CreatedAt = dto.CreatedAt;
            skill.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileservices.UploadFilesToDatabase(dto, skill);
            }

            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();

            return skill;
        }
        public async Task<Skill> Delete(Guid id)
        {
            var result = await _context.Skills
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Skills.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
