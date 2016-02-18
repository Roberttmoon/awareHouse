using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Route
    {
        [Key]
        public int routeID { get; set; }
        public DateTime checkoutTime { get; set; }
        public bool isDeadhead { get; set; }

        public DateTime placePallet { get; set; }
        public DateTime pickPallet { get; set; }

    }
}