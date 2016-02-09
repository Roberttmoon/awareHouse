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
        public int employeeFK { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        public int addressFK { get; set; }
        [Required]
        public virtual Address Address { get; set; }
    }
}