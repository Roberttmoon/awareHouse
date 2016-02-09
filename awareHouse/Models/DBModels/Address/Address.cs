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
        public int cityID { get; set; }
        [Required]
        public City City{get;set;}
        public int stateID { get; set; }
        [Required]
        public State State{get;set;}
        public int streetAddressID { get; set; }
        [Required]
        public StreetAddress StreetAddress { get;set;}
        public int zipCodeID { get; set; }
        [Required]
        public ZipCode ZipCode {get;set;}
}
}