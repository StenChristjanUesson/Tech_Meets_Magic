namespace TechMeetsMagic.Models.TheGeneratedUserMadeOpenWorld
{
    public class TheUserMadeOpenWorldDetailsViewModel
    {
        public Guid ID { get; set; }
        public string WorldName { get; set; }
        public string WorldDescription { get; set; }
        public string WorldImageUrl { get; set; }
        public string WorldMapUrl { get; set; }

        //public List<IFormFile> Files { get; set; }
        public List<TheUserMadeOpenWorldImageViewModel> Images { get; set; } = new List<TheUserMadeOpenWorldImageViewModel>();
    }
}
