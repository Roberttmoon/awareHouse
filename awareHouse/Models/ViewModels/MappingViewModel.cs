using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class MappingViewModel
    {
        [Display(Name = "Building Name")]
        public Building building { get; set; }
        [Display(Name = "Number of rows")]
        public Row row { get; set; }
        [Display(Name = "Number of bays per row")]
        public Bay bays { get; set; }
        [Display(Name = "Shelves per Bay")]
        public Height height { get; set; }
        [Display(Name = "Pallet spots per Shelf")]
        public Slot slots { get; set; }
        public int countHolder { get; set; }
        public int secondHolder { get; set; }
    }
}