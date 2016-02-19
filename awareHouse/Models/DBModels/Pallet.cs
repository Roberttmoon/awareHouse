using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Pallet
    {
        [Key]
        public int palletID { get; set; }
        [Required]
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }

        //[ForeignKey("Dock")]
        //public int DockID { get; set; }
        //public virtual Dock Dock { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        //public int slotFK { get; set; }
        //[Required]
        //public Slot Slot { get; set; }

        public bool awaitingPick { get; set; } = false;
        public bool picked { get; set; } = false;
        public int picklistID { get; set; }
        public virtual Picklist Picklist { get; set; }
    }
}