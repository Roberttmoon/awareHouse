using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Row
    {
        [Key]
        public int rowID { get; set; }
        [Required]
        public int row { get; set; }
    }
}