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
        public DbSet<NPC> NPCs { get; set; }
    }
}
