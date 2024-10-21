using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Dto
{
    public enum NpcType
    {
        QuestGiver, Companion, Researcher, Hostile, Tutorial,
    }
    public enum NPCStatus
    {
        Dead, Paralized, InFear, KnockedOut, Sleeping
    }
    public class NpcDto
    {
        public Guid ID { get; set; }
        public string? NPCName { get; set; }
        public string? NPCDescribtion { get; set; }
        public int NPCLevel { get; set; }
        public NPCStatus NPCStatus { get; set; }
        public int NPCMaxHP { get; set; }
        public int NPCCurrentHP { get; set; }
        public int NPCAttackDamage { get; set; }
        public NpcType NpcType { get; set; }

        //image
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> image { get; set; } = new List<FileToDatabaseDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
