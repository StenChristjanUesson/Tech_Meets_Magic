using System.Net.NetworkInformation;

namespace TechMeetsMagic.Models.ItemBlueprints
{
    public enum BlueprintItemType
    {
        QuestItem, Weapon, Armor, Consumable, Miscellaneous
    }
    public class BlueprintIndexViewModel
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
