using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Domain;

namespace TechMeetsMagic.Core.Dto
{
    public enum BlueprintItemType
    {
        QuestItem, Weapon, Armor, Consumable, Miscellaneous
    }
    public class BlueprintDto
    {
        public Guid ID { get; set; }
        public string BlueprintName { get; set; }
        public string Resources_Needed { get; set; }
        public BlueprintItemType BlueprintItemType { get; set; }
        
        //image
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> image { get; set; } = new List<FileToDatabaseDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
