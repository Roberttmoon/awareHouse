using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }
        public string employeeName { get; set; }

        //[Required]
        //[ForeignKey("ApplicationUser")]
        //public string UserID { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}