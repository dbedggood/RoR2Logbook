using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoR2Logbook.Models;

namespace RoR2Logbook.Models
{
    public class RoR2LogbookContext : DbContext
    {
        public RoR2LogbookContext (DbContextOptions<RoR2LogbookContext> options)
            : base(options)
        {
        }

        public DbSet<RoR2Logbook.Models.Item> Item { get; set; }

        public DbSet<RoR2Logbook.Models.Survivor> Survivor { get; set; }
    }
}
