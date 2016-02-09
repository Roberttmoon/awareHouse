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
        public int palletLocationID { get; set; }
        public virtual PalletLocation PalletLocation { get; set; }
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }
        [Required]
        public int shipToLocationID { get; set; }
        public virtual Addresses Adresses {get; set;}
        [Required]
        public int ownerID { get; set; }
        public virtual Owner Owner { get; set; }
}
}