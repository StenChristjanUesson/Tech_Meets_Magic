using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Dto
{
    public enum AvatarSkinColor
    {
        Pale_white, White_to_light_beige, Beige, Light_brown, Moderate_brown, Dark_brown_or_black
    }
    public enum AvatarHairLenght
    {
        Short, Medium, Long
    }
    public enum AvatarEyeColor
    {
        red, orange, yellow, green, blue, purple, brown, black, white
    }
    public enum AvatarGender
    {
        male, female
    }
    public enum AvatarHairColor
    {
        blond, bleached_blond, brown, black, red, gray, white, blue, green, purple, pink
    }
    public class AvatarDto
    {
        public Guid ID { get; set; }
        public AvatarGender? AvatarGender { get; set; }
        public AvatarSkinColor? AvatarSkinColor { get; set; }
        public AvatarHairColor? AvatarHairColor { get; set; }
        public AvatarHairLenght? AvatarHairLenght { get; set; }
        public AvatarEyeColor? AvatarEyeColor { get; set; }

        //image
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> image { get; set; } = new List<FileToDatabaseDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
