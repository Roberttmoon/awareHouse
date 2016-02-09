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
        public int customerID { get; set; }
        [Required]
        public Customer Customer { get; set; }
        public int addressID { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}