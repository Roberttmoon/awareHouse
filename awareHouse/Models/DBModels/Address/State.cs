using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace awareHouse.Models
{
    public class State
    {
        [Key]
        public int stateID { get; set; }
        [Required]
        public string stateName { get; set; }
    }
}