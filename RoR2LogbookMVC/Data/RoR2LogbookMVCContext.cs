using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RoR2LogbookMVC.Models
{
    public class RoR2LogbookMVCContext : DbContext
    {
        public RoR2LogbookMVCContext (DbContextOptions<RoR2LogbookMVCContext> options)
            : base(options)
        {
        }

        public DbSet<RoR2LogbookMVC.Models.Item> Item { get; set; }
    }
}
