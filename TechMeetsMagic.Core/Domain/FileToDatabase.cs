using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Domain
{
    public class FileToDatabase
    {
        public Guid ID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? NpcId { get; set; }
        public Guid? AvatarId { get; set; }
        public Guid? SkillId { get; set; }
        public Guid? TheUserMadeOpenWorldId { get; set; }
        public Guid? BlueprintId { get; set; }
    }
}
