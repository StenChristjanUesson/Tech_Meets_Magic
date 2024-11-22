﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Dto
{
    public class AvatarDto
    {
        public enum AvatarGender
        {
            Male, Female, Monster, Machine
        }
        public enum AvatarStatus
        {
            Dead, Paralized, Fear, KnockedOut, Sleeping
        }
        public class Avatar
        {
            public Guid ID { get; set; }
            public string? AvatarDescribtion { get; set; }
            public int AvatarLevel { get; set; }
            public int AvatarMaxHP { get; set; }
            public int AvatarCurrentHP { get; set; }
            public AvatarStatus AvatarStatus { get; set; }
            public int AvatarAttackDamage { get; set; }
            public AvatarGender AvatarGender { get; set; }

            //image
            public List<IFormFile> Files { get; set; }
            public IEnumerable<FileToDatabaseDto> image { get; set; } = new List<FileToDatabaseDto>();

            // db only
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }
    }
}