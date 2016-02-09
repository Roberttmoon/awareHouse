using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Slot
    {
        [Key]
        public int slotID { get; set; }
        [Required]
        public int slot { get; set; }
        public int bayFK { get; set; }
        [Required]
        public virtual Bay Bay { get; set; }
        public bool awaitingPallet { get; set; }
        public bool lockoutTagout { get; set; }
    }
}