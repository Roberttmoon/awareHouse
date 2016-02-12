using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int employeeAddressID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
    }
}