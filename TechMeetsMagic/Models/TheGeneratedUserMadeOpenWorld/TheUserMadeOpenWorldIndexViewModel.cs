using System.Net.NetworkInformation;

namespace TechMeetsMagic.Models.TheGeneratedUserMadeOpenWorld
{
    public class TheUserMadeOpenWorldIndexViewModel
    {
        public Guid ID { get; set; }
        public string WorldName { get; set; }
        public string WorldDescription { get; set; }
        public string WorldImageUrl { get; set; }
        public string WorldMapUrl { get; set; }

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
