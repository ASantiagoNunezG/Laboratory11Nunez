using System.ComponentModel.DataAnnotations;

namespace Laboratory11Nunez.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
    }
}
