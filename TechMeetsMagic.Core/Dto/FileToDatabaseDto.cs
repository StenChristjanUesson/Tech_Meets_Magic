using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Dto
{
    public class FileToDatabaseDto
    {
        public Guid ID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? NpcID { get; set; }
        public Guid? AvatarID { get; set; }
        public Guid? SkillID { get; set; }
        public Guid? BlueprintID { get; set; }
        public Guid? TheUserMadeOpenWorldID { get; set; }
    }
}
