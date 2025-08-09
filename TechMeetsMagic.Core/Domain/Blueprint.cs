using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Domain
{
    public enum BlueprintItemType
    {
        QuestItem, Weapon, Armor, Consumable, Miscellaneous
    }
    public class Blueprint
    {
        public Guid ID { get; set; }
        public string BlueprintName { get; set; }
        public string Resources_Needed { get; set; }
        public BlueprintItemType BlueprintItemType { get; set; }
 
        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
