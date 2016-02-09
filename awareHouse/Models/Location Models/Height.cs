using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Height
    {
        [Key]
        public int heightID { get; set; }
        [Required]
        public int height { get; set; }
    }
}