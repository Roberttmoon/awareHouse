using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Bay
    {
        [Key]
        public int bayID{get;set; }
        public int bayNumber { get; set; }

        [NotMapped]
        public int numberOfHeights { get; set; }

        [Required]
        [ForeignKey("Row")]
        public int rowID { get; set; }
        public virtual Row Row { get; set; }

        public virtual ICollection<Height> Heights { get; set; }
    }
}