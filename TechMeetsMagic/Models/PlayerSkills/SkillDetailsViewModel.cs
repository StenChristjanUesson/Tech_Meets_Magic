namespace TechMeetsMagic.Models.PlayerSkills
{
    public class SkillDetailsViewModel
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

        //public List<IFormFile> Files { get; set; }
        public List<SkillImageViewModel> Images { get; set; } = new List<SkillImageViewModel>();
    }
}
