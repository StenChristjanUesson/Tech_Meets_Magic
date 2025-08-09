using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMeetsMagic.Core.Dto;

namespace TechMeetsMagic.Core.Domain
{
    public class TheUserMadeOpenWorld
    {
        public Guid ID { get; set; }
        public string WorldName { get; set; }
        public string WorldDescription { get; set; }
        public string WorldImageUrl { get; set; }
        public string WorldMapUrl { get; set; }

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
