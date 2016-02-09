using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }
        public string employeeName { get; set; }
    }
}