using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Touch
    {
        [Key]
        public int touchID { get; set; }
        public DateTime touchTime { get; set; }
        public int slotFK { get; set; }
        [Required]
        public Slot Slot { get; set; }
        public int palletFK { get; set; }
        [Required]
        public virtual Pallet Pallet { get; set; }
        public int employeeFK { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
    }
}