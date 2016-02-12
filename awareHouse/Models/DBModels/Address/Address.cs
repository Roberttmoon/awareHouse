using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class Address
    {
        [Key]
        public int addressID { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityID { get; set; }
        public virtual City City {get;set;}

        [Required]
        [ForeignKey("State")]
        public int StateID { get; set; }
        public virtual State State{get;set;}

        [Required]
        [ForeignKey("StreetAddress")]
        public int StreetAddressID { get; set; }
        public virtual StreetAddress StreetAddress { get;set;}

        [Required]
        [ForeignKey("ZipCode")]
        public int ZipCodeID { get; set; }
        public virtual ZipCode ZipCode {get;set;}
}
}