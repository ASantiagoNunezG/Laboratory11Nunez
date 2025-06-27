namespace Lab12.Response
{
    public class DetailByDateResponse
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceTotal { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public float ProductPrice { get; set; }

        public int Amount { get; set; }
        public decimal SubTotal { get; set; }
    }
}
