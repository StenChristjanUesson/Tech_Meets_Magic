﻿using System.Net.NetworkInformation;

namespace TechMeetsMagic.Models.PlayerAvatars
{
    namespace TechMeetsMagic.Core.Domain
    {
        public enum AvatarGender
        {
            Male, Female, Monster, Machine
        }
        public enum AvatarStatus
        {
            Dead, Paralized, Fear, KnockedOut, Sleeping
        }
        internal class AvatarIndexViewModels
        {
            public Guid ID { get; set; }
            public string? AvatarDescribtion { get; set; }
            public int AvatarLevel { get; set; }
            public int AvatarMaxHP { get; set; }
            public int AvatarCurrentHP { get; set; }
            public AvatarStatus AvatarStatus { get; set; }
            public int AvatarAttackDamage { get; set; }
            public AvatarGender AvatarGender { get; set; }

            //db only
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}
