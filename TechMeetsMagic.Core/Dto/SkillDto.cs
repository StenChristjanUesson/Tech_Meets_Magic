using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;

namespace TechMeetsMagic.Core.Dto
{
    public enum SkillActiveType
    {
        Passive, Active, PassiveAndActive
    }
    public enum SkillTreeCategory
    {
        Crafting, Combat, Exploration, Social
    }
    public enum SkillType
    {
        Healing, Damage, Buff, Debuff, Utility, Other
    }
    public class SkillDto
    {
        public Guid ID { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public SkillActiveType SkillActiveType { get; set; }
        public SkillType SkillType { get; set; }
        public SkillTreeCategory SkillTreeCategory { get; set; }
        public int HealthAmountGainedFromHealingSkill { get; set; }
        public int SkillDamage { get; set; }
        public int SkillmaxRange { get; set; }
        public int SkillRangeStart { get; set; }
        public int SkillActivationRangeStart { get; set; }
        public string SkillHitboxContactAffect { get; set; }
        
        //image
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> image { get; set; } = new List<FileToDatabaseDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
