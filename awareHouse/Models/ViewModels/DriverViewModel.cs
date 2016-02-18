using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class DriverViewModel
    {
        public Pallet palletToPlace { get; set; }
        public Pallet palletToPick { get; set; }

        public Touch Touch { get; set; }
        public Employee Employee { get; set; }

    }
}