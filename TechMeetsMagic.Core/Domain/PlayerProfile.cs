using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Domain
{
    public enum ProfileStatus
    {
        Active, Abandoned, Deactivated, Locked, Banned, ManualReviewNecessary
    }
    public class PlayerProfile
    {
        public Guid ID { get; set; }
        public string ApplicationUserID { get; set; } // 1-1
        public string ScreenName { get; set; }
        public ProfileStatus CurrentStatus { get; set; }

        public bool ProfileType { get; set; } //true, admin, false, player

        //dbonly
        public DateTime ProfileCreatedAt { get; set; }
        public DateTime ProfileModifiedAt { get; set; }
        public DateTime ProfileAttributedToAnAccountUserAt { get; set; }
        public DateTime ProfileStatusLastChangedAt { get; set; }

    }
}