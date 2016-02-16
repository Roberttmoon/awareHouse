using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Slot
    {
        [Key]
        public int slotID { get; set; }
        [Required]
        public int slotNumber { get; set; }


        [Required]
        [ForeignKey("Height")]
        public int heightID { get; set; }
        public virtual Height Height { get; set; }

        public bool awaitingPallet { get; set; }
        public bool lockoutTagout { get; set; }
    }
}