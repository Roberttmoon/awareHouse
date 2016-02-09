using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class EmployeeAddress
    {
        [Key]
        public int employeeAddressID { get; set; }
        public int employeeID { get; set; }
        [Required]
        public Employee Employee { get; set; }
        public int addressID { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}