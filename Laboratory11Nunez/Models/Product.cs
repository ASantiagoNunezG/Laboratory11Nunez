namespace Laboratory11Nunez.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public bool Active { get; set; } = true;
    }
}
