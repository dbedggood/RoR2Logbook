using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace RoR2LogbookMVC.Models
{
    // Populates database on startup if empty.
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RoR2LogbookMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RoR2LogbookMVCContext>>()))
            {
                // Look for any items or survivors.
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
                        PickupText = "Increases attack speed.",
                        OrderNo = 1
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
                        OrderNo = 1
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
