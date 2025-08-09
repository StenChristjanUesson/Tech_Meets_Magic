namespace TechMeetsMagic.Models.ItemBlueprints
{

    public class BlueprintCreateViewModels
    {
        public Guid ID { get; set; }
        public string BlueprintName { get; set; }
        public string Resources_Needed { get; set; }
        public BlueprintItemType BlueprintItemType { get; set; }

        public List<IFormFile> Files { get; set; }
        public List<BlueprintImageViewModel> Images { get; set; } = new List<BlueprintImageViewModel>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
