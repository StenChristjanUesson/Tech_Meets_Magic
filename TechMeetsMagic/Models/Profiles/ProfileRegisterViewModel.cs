using TechMeetsMagic.Core.Domain;
namespace GalacticTitans.Models.Profiles
{
    public class ProfileRegisterViewModel
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; }
        public string ScreenName { get; set; }
        public ProfileStatus CurrentStatus { get; set; }
        public bool ProfileType { get; set; } //true, admin, false, player
    }
}