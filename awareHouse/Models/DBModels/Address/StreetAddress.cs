using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class StreetAddress
    {
        [Key]
        public int streetAddressID{get;set;}
        [Required]
        public string streetLineOne { get; set; }
        public string streetLineTwo { get; set; }
    }
}