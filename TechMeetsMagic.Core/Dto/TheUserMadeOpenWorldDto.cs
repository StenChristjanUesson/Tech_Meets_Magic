using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Core.Dto
{
    public class TheUserMadeOpenWorldDto
    {
        public Guid ID { get; set; }
        public string WorldName { get; set; }
        public string WorldDescription { get; set; }
        public string WorldImageUrl { get; set; }
        public string WorldMapUrl { get; set; }
        
        //image
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> image { get; set; } = new List<FileToDatabaseDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
