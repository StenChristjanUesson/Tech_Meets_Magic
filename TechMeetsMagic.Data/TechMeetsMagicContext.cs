using TechMeetsMagic.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechMeetsMagic.Data
{
    public class TechMeetsMagicContext : DbContext
    {
        public TechMeetsMagicContext(DbContextOptions<TechMeetsMagicContext> options) : base(options) { }
        public DbSet<NPC> NPCs { get; set; }
        public DbSet<Avatar> Avatar { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
