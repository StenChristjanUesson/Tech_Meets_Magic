namespace TechMeetsMagic.Models.NonPlayerCharacters
{
    public class NpcDetailsViewModel
    {
        public Guid ID { get; set; }
        public string? NPCName { get; set; }
        public string? NPCDescribtion { get; set; }
        public int NPCLevel { get; set; }
        public NPCStatus NPCStatus { get; set; }
        public int NPCMaxHP { get; set; }
        public int NPCCurrentHP { get; set; }
        public int NPCAttackDamage { get; set; }
        public NPCType NpcType { get; set; }

        //public List<IFormFile> Files { get; set; }
        public List<NpcImageViewModel> Images { get; set; } = new List<NpcImageViewModel>();
    }
}
