using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoR2LogbookMVC.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
