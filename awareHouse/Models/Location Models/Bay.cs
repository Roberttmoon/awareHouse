using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Bay
    {
        [Key]
        public int bayID { get; set; }
        [Required]
        public int bay { get; set; }
    }
}