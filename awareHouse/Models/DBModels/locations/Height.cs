using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Height
    {
        [Key]
        public int heightID { get; set; }
        [Required]
        public int heightNumber { get; set; }

        [NotMapped]
        public int numberOfSlots { get; set; }

        [Required]
        [ForeignKey("Bay")]
        public int BayID { get; set; }
        public virtual Bay Bay { get; set; }

        public ICollection<Slot> Slots { get; set; }
    }
}