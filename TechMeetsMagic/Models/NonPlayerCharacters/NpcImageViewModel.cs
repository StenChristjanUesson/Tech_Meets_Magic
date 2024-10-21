namespace TechMeetsMagic.Models.NonPlayerCharacters
{
    public class NpcImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string image { get; set; }
        public Guid? NpcID { get; set; }
    }
}
