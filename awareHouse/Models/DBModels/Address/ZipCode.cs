using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class ZipCode
    {
        [Key]
        public int zipcodeID { get; set; }
        [Required]
        public int zipCode { get; set; }
    }
}