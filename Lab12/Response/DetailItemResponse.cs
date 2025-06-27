namespace Lab12.Response
{
    public class DetailItemResponse
    {
        public string ProductName { get; set; } = string.Empty;
        public float ProductPrice { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal { get; set; }
    }
}
