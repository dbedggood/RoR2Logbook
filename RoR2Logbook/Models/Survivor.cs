namespace RoR2Logbook.Models
{
    public class Survivor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public float BaseMaxHealth { get; set; }
        public float MaxHealthIncrease { get; set; }
        public float BaseDamage { get; set; }
        public float DamageIncrease { get; set; }
        public float Speed { get; set; }
        public string Notes { get; set; }
    }
}
