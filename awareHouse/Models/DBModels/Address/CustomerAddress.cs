using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class CustomerAddress
    {
        [Key]
        public int customerAddressID { get; set; }
        public int customerFK { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        public int addressFK { get; set; }
        [Required]
        public virtual Address Address { get; set; }
    }
}