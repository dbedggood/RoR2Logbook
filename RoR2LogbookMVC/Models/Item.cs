using System.ComponentModel.DataAnnotations;

namespace RoR2LogbookMVC.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
