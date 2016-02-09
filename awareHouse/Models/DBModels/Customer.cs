using System.ComponentModel.DataAnnotations;

namespace awareHouse.Models
{
    public class Customer
    {
        [Key]
        public int customerID { get; set; }
        public string customerName { get; set; }
    }
}