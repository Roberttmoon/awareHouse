using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Picklist
    {
        [Key]
        public int picklistID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }

    }
}