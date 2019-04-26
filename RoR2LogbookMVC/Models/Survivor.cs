using System.ComponentModel.DataAnnotations;

namespace RoR2LogbookMVC.Models
{
    public class Survivor
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public float BaseMaxHealth { get; set; }
        [Required]
        public float MaxHealthIncrease { get; set; }
        [Required]
        public float BaseDamage { get; set; }
        [Required]
        public float DamageIncrease { get; set; }
        [Required]
        public float Speed { get; set; }
        public string Notes { get; set; }
    }
}
