using TechMeetsMagic.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TechMeetsMagic.Data
{
    public class TechMeetsMagicContext : IdentityDbContext<ApplicationUser>
    {
        public TechMeetsMagicContext(DbContextOptions<TechMeetsMagicContext> options) : base(options) { }
        public DbSet<NPC> NPCs { get; set; }
        //public DbSet<Avatar> Avatars { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
        public DbSet<IdentityRole> identityRoles { get; set; }
    }
}
