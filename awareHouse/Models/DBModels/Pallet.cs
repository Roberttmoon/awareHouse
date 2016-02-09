using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int customerFK { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        //public int slotFK { get; set; }
        //[Required]
        //public Slot Slot { get; set; }
    }
}