using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Domain
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
    public class Skill
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
        
        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
