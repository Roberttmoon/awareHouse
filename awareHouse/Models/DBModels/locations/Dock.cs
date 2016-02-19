using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Dock
    {
        [Key]
        public int dockID { get; set; }
        
        [ForeignKey("Building")]
        public int buildingID { get; set; }
        public virtual Building Building { get; set; }

        
    }
}