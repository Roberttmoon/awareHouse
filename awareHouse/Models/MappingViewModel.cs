using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class MappingViewModel
    {
        [Display(Name = "Number of rows")]
        public int row { get; set; }
        [Display(Name = "Number of bays per row")]
        public int bays { get; set; }
        [Display(Name = "Shelves per Bay")]
        public int height { get; set; }
        [Display(Name = "Pallet spots per Shelf")]
        public int slots { get; set; }
    }
}