using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Touch
    {
        [Key]
        public int touchID { get; set; }
        public DateTime touchTime { get; set; }

        [Required]
        [ForeignKey("Slot")]
        public int SlotID { get; set; }
        public Slot Slot { get; set; }

        [Required]
        [ForeignKey("Pallet")]
        public int PalletID { get; set; }
        public virtual Pallet Pallet { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Route")]
        public int routeID { get; set; }
        public virtual Route Route { get; set; }
    }
}