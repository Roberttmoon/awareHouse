using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Row
    {
        [Key]
        public int rowID { get; set; }
        [Required]
        public int rowNumber { get; set; }

        [Required]
        [ForeignKey("Building")]
        public int BuildingID { get; set; }
        public virtual Building Building { get; set; }

        public virtual ICollection<Bay> Bays { get; set; }
    }
}