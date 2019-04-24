using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RoR2Logbook.Models

{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RoR2LogbookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RoR2LogbookContext>>()))
            {
                // Look for any Items.
                if (context.Item.Any())
                {
                    return;   // DB has been seeded
                }

                context.Item.AddRange(
                    new Item
                    {
                        Name = "Soldier's Syringe",
                        Description = "Increases attack speed by 15% (+15% per stack).",
                        Type = "tier1"
                    },

                    new Item
                    {
                        Name = "Shaped Glass",
                        Description = "Increase base damage by 100% (+100% per stack). Reduce maximum health by 50% (+50% per stack).",
                        Type = "lunar"
                    },

                    new Item
                    {
                        Name = "Radar Scanner",
                        Description = "Reveal all interactables within 500m for 10 seconds.",
                        Type = "equipment"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}