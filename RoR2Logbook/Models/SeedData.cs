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
                if (context.Item.Any() || context.Survivor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Item.AddRange(
                    new Item
                    {
                        Icon = "../../images/tier1/Syringe.png",
                        Name = "Soldier's Syringe",
                        Description = "Increases attack speed by 15% (+15% per stack).",
                        Type = "tier1",
                        Notes = "make you go fast zoom zoom haha lol"
                    },

                    new Item
                    {
                        Icon = "../../images/lunar/LunarDagger.png",
                        Name = "Shaped Glass",
                        Description = "Increase base damage by 100% (+100% per stack). Reduce maximum health by 50% (+50% per stack).",
                        Type = "lunar",
                        Notes = "make you do big damage but sometimes you die"
                    },

                    new Item
                    {
                        Icon = "../../images/equipment/Scanner.png",
                        Name = "Radar Scanner",
                        Description = "Reveal all interactables within 500m for 10 seconds.",
                        Type = "equipment",
                        Notes = "make you find loot good"
                    }
                );

                context.Survivor.AddRange(
                    new Survivor
                    {
                        Icon = "../../images/survivor/Commando.png",
                        Name = "Commando",
                        BaseMaxHealth = 110f,
                        MaxHealthIncrease = 33f,
                        BaseDamage = 12f,
                        DamageIncrease = 2.4f,
                        Speed = 7f,
                        Notes = "this guy kinda boring"
                    },

                    new Survivor
                    {
                        Icon = "../../images/survivor/Engi.png",
                        Name = "Engineer",
                        BaseMaxHealth = 130f,
                        MaxHealthIncrease = 39f,
                        BaseDamage = 14f,
                        DamageIncrease = 2.8f,
                        Speed = 7f,
                        Notes = "super mega ultra chad"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}