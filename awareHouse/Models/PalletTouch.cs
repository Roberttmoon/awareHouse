using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class PalletTouch
    {
        [Key]
        public int palletTouchID{get;set;}
        public DateTime touchTime { get; set; }
        public int previousLocation { get; set; }
        public virtual PalletLocation PalletLocation { get; set; }
    }
}