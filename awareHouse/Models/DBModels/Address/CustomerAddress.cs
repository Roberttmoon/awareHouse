using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class CustomerAddress
    {
        [Key]
        public int customerAddressID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        
        [Required]
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
    }
}