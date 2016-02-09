using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Pallet
    {
        [Key]
        public int palletID { get; set; }
        [Required]
        public DateTime inDate { get; set; }
        public DateTime outDate { get; set; }
        public int customerID { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}