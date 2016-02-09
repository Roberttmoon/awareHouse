using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Address
    {
        [Key]
        public int addressID { get; set; }
        public int cityFK { get; set; }
        [Required]
        public virtual City City {get;set;}
        public int stateFK { get; set; }
        [Required]
        public virtual State State{get;set;}
        public int streetAddressFK { get; set; }
        [Required]
        public virtual StreetAddress StreetAddress { get;set;}
        public int zipCodeFK { get; set; }
        [Required]
        public virtual ZipCode ZipCode {get;set;}
}
}