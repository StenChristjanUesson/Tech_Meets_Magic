namespace TechMeetsMagic.Models.AvatarAppearence
{
    public class AvatarCreateViewModels
    {
        public Guid ID { get; set; }
        public AvatarGender? AvatarGender { get; set; }
        public AvatarSkinColor? AvatarSkinColor { get; set; }
        public AvatarHairColor? AvatarHairColor { get; set; }
        public AvatarHairLenght? AvatarHairLenght { get; set; }
        public AvatarEyeColor? AvatarEyeColor { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<AvatarImageViewModel> Images { get; set; } = new List<AvatarImageViewModel>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
