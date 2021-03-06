﻿using System.ComponentModel.DataAnnotations;

namespace RoR2LogbookMVC.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Name { get; set; }
        public int OrderNo { get; set; }
        [Required]
        public string Type { get; set; }
        [Display(Name = "Pickup Text")]
        public string PickupText { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Unlock")]
        public string Challenge { get; set; }
        public string Notes { get; set; }
    }
}
