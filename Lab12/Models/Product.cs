using System.Text.Json.Serialization;

namespace Lab12.Models
{
    public class Product
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        [JsonIgnore]
        public bool Active { get; set; } = true;
    }
}
