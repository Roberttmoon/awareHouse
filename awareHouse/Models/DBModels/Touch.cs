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
        public int slotID { get; set; }
        [Required]
        public Slot Slot { get; set; }
        public int palletID { get; set; }
        [Required]
        public Pallet Pallet { get; set; }
        public int employeeID { get; set; }
        [Required]
        public Employee Employee { get; set; }
    }
}