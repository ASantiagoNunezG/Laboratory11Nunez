using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Lab12.Models
{

        public class Customer
    {
        [JsonIgnore]
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        [JsonIgnore]
        public bool Active { get; set; } = true;
    }
}
