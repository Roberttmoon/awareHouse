using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class PalletLocation
    {
        [Key]
        public int palletLocation { get; set; }
        public int palletID { get; set; }
        [Required]
        public int rowID {get; set;}
        public virtual Row Row { get; set; }
        [Required]
        public int heightID {get; set;}
        public virtual Height Height { get; set; }
        [Required]
        public int bayID {get; set;}
        public virtual Bay Bay { get; set; }
        [Required]
        public int slotID {get; set;}
        public virtual Slot Slot { get; set; }
        public bool hasPallet { get; set; }
        public bool awatingPallet { get; set; }
        public bool lockoutTagout { get; set; }
    }
}