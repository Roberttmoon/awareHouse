using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Building
    {
        [Key]
        public int buildingID { get; set; }
        public string buildingName { get; set; }

        public virtual ICollection<Row> Rows { get; set; }
    }
}