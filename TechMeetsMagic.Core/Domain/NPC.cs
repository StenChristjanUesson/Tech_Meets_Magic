using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Domain
{
    public enum NpcType
    {
        QuestGiver, Companion, Researcher, Hostile, Tutorial, 
    }
    public enum NPCStatus
    {
        Dead, Paralized, InFear, KnockedOut, Sleeping
    }
    public class NPC
    {
        public Guid ID { get; set; }
        public string NPCName { get; set; }
        public string NPCDescribtion { get; set; }
        public NPCStatus NPCStatus { get; set; }
        public int NPCMaxHP { get; set; }
        public int NPCCurrentHP { get; set; }
        public int NPCAttackDamage {  get; set; }
        public NpcType NpcType { get; set; }

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
