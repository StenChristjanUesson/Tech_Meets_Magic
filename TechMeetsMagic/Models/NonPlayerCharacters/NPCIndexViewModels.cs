using System.Net.NetworkInformation;

namespace TechMeetsMagic.Models.NonPlayerCharacters
{
    public enum NPCType
    {
        QuestGiver, Companion, Researcher, Hostile, Tutorial,
    }
    public enum NPCStatus
    {
        Dead, Paralized, InFear, KnockedOut, Sleeping
    }
    public class NpcIndexViewModels
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

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
